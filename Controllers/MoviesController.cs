﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using POC.Models;
using POC.ViewModels;

namespace POC.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;


        public MoviesController() {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            var Genres = _context.Genres.ToList();


            var viewModel = new MovieFormViewModel
            {

                Genre = Genres
            };

            return View("MovieForm",viewModel);
        }


        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();

            return View(movies);
           
        }

        public ActionResult Edit(int id)
        {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movies,
                Genre = _context.Genres.ToList()

            };

            return View("MovieForm",viewModel);
        }
    }
}