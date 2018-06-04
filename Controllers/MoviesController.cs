using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using POC.Models;
using POC.ViewModels;

namespace POC.Controllers {
    public class MoviesController : Controller {

        private ApplicationDbContext _context;


        public MoviesController() {
            _context = new ApplicationDbContext();
        }


        protected override void Dispose(bool disposing) {
            _context.Dispose();
        }


        public ActionResult New() {
            var Genres = _context.Genres.ToList();


            var viewModel = new MovieFormViewModel {

                Genre = Genres
            };

            return View("MovieForm", viewModel);
        }


        public ViewResult Index()
        {
            return View();    
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie) {

            if (!ModelState.IsValid) {
                var viewModel = new MovieFormViewModel(movie) {
                    Genre = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }


            if (movie.Id == 0) {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            } else {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.DateReleased = movie.DateReleased;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;


            }
           _context.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }





        public ActionResult Edit(int id) {
            var movies = _context.Movies.SingleOrDefault(c => c.Id == id);

            if (movies == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movies) {

                Genre = _context.Genres.ToList()

            };

            return View("MovieForm", viewModel);
        }
    }
}