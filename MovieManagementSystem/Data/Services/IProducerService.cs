using MovieManagementSystem.Models;
using System.Collections.Generic;

namespace MovieManagementSystem.Data.Services
{
    public interface IProducerService
    {
        IEnumerable<Producer> GetAll();
        Producer GetById(int id);
        void Add(Producer producer);
        Producer Update(int id, Producer newProducer);
        void Delete(int id);
    }
}
