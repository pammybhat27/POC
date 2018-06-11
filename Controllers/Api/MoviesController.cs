﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using AutoMapper;
using POC.Dto;
using POC.Models;

namespace POC.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context =  new ApplicationDbContext();
        }


        //GET /api/Movies
        public IHttpActionResult GetMovies(string query = null)
        {
            //Display the movies only if they are > 0 
            var movieQuery = _context.Movies
                .Include(c => c.Genre).Where(c=>c.NumberAvailable > 0);
            
            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(c => c.Name.Contains(query));

            var movieDtos    =   movieQuery
                                .ToList()
                               .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(movieDtos);
        }

        //GET /api/Movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie,MovieDto>(movie));

        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();


            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }
        
        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if(movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.Found);

            Mapper.Map<MovieDto, Movie>(movieDto);
            movieInDb.DateAdded = movieDto.DateAdded;
            movieInDb.DateReleased = movieDto.DateReleased;
            movieInDb.Name = movieDto.Name;
            movieInDb.GenreId = movieDto.GenreId;
            movieInDb.NumberInStock = movieDto.NumberInStock;

            _context.SaveChanges();

        }

        //Delete api/customers/1
        [HttpDelete]
        public void DeleteMovie(int id) {
            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }



    }
}
