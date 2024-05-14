using MovieManagementSystem.Models;

namespace MovieManagementSystem.Data.Services
{
    public interface ICinemaService
    {
        IEnumerable<Cinema> GetAll();
        Cinema GetById(int id);

        void Add(Cinema cinema);

        Cinema Update(int id, Cinema newCinema);

        void Delete(int id);
    }
}
