using MovieManagementSystem.Models;
using System.Collections.Generic;

namespace MovieManagementSystem.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<Actor> GetAll();
        Actor GetById(int id);

        void Add(Actor actor);

       Actor Update(int id,Actor newActor);

        void Delete(int id);
        //Task GetByIdAsync(int id);
    }
}
