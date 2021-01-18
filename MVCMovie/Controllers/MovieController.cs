﻿using MVCMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCMovie.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> movies = Session["movies"] as List<Movie>;
            return View(movies);
        }
        public ActionResult Index1(string searchString)
        {
            List<Movie> movies = Session["movies"] as List<Movie>;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Genre.Contains(searchString)).ToList();
            }
            return View(movies);
        }

        // GET: Movie/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie m)
        {
            if (ModelState.IsValid)
            {
                List<Movie> movies = Session["movies"] as List<Movie>;
            if (movies == null)
            {
                movies = new List<Movie>();
            }
            movies.Add(m);
            Session["movies"] = movies;
            return RedirectToAction("Index1");
            }
            return View(m);
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
