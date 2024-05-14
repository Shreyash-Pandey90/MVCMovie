using MovieManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace MovieManagementSystem.Data.Services
{
    public class CinemaService : ICinemaService
    {
        private readonly AppDbContext _context;

        public CinemaService()
        {
            _context = new AppDbContext();
        }

        public void Add(Cinema cinema)
        {
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            _context.Cinemas.Remove(result);

            _context.SaveChanges();
        }

        public IEnumerable<Cinema> GetAll()
        {
            return _context.Cinemas;
        }

        public Cinema GetById(int id)
        {
            var result = _context.Cinemas.FirstOrDefault(n => n.Id == id);
            return result;
        }

        public Cinema Update(int id, Cinema newCinema)
        {
            _context.Update(newCinema);
            _context.SaveChanges();
            return newCinema;
        }

    }
}
