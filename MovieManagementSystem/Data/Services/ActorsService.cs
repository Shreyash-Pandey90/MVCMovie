using MovieManagementSystem.Models;
using System;
using System.Collections.Generic;

namespace MovieManagementSystem.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService()
        {
            _context =new AppDbContext();
        }

        public void Add(Actor actor)
        {
            _context.Actors.Add(actor);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result=_context.Actors.FirstOrDefault(n => n.Id == id);
            _context.Actors.Remove(result);

            _context.SaveChanges();
        }

        public IEnumerable<Actor> GetAll()
        {
            return _context.Actors;
        }

        public Actor GetById(int id)
        {
            var result = _context.Actors.FirstOrDefault(n => n.Id == id);
            return result;
        }

        public Actor Update(int id,Actor newActor)
        {
            _context.Update(newActor);
            _context.SaveChanges();
            return newActor;
        }

    }
}
