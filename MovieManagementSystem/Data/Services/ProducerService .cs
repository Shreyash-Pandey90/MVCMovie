using MovieManagementSystem.Models;
using System.Linq;
using System.Collections.Generic;

namespace MovieManagementSystem.Data.Services
{
    public class ProducerService : IProducerService
    {
        private readonly AppDbContext _context;

        public ProducerService()
        {
            _context = new AppDbContext();
        }

        public void Add(Producer producer)
        {
            _context.Producers.Add(producer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var result = _context.Producers.FirstOrDefault(n => n.Id == id);
            _context.Producers.Remove(result);
            _context.SaveChanges();
        }

        public IEnumerable<Producer> GetAll()
        {
            return _context.Producers;
        }

        public Producer GetById(int id)
        {
            var result = _context.Producers.FirstOrDefault(n => n.Id == id);
            return result;
        }

        public Producer Update(int id, Producer newProducer)
        {
            _context.Update(newProducer);
            _context.SaveChanges();
            return newProducer;
        }
    }
}
