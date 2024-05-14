using MovieManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieManagementSystem.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly AppDbContext _context;

        public MovieService()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(int id, Movie movie)
        {
            var existingMovie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (existingMovie != null)
            {
                existingMovie.Name = movie.Name;
                existingMovie.Description = movie.Description;
                existingMovie.Price = movie.Price;
                existingMovie.ImageURL = movie.ImageURL;
                existingMovie.StartDate = movie.StartDate;
                existingMovie.EndDate = movie.EndDate;
                existingMovie.MovieCattegory = movie.MovieCattegory;
                existingMovie.CinemaId = movie.CinemaId;
                existingMovie.ProducerId = movie.ProducerId;

                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var movieToDelete = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                _context.SaveChanges();
            }
        }
    }
}
