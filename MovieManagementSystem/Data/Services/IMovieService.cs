using MovieManagementSystem.Models;
using System.Collections.Generic;

namespace MovieManagementSystem.Data.Services
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        void Add(Movie movie);
        void Update(int id, Movie movie);
        void Delete(int id);
    }
}
