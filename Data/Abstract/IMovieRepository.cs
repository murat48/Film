using Film.Models;
using Film.ViewModels;

namespace Film.Data.Abstract
{
    public interface IMovieRepository
    {
        IQueryable<Movie> Movies { get; }

        void AddMovie(Movie movie);
        void UpdateMovie(int id);
        void DeleteMovie(int id);
        void UpdateMovies(MovieViewModel model, int catid, string imageFile);
        IEnumerable<Movie> GetMoviesByCategory(int id);
    }
}