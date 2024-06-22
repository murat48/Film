using Film.Data.Abstract;
using Film.Models;
using Film.ViewModels;

namespace Film.Data.Concrete.EfCore
{
    public class EfMovieRepository : IMovieRepository
    {
        private MovieContext _movieContext;
        public EfMovieRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IQueryable<Movie> Movies => _movieContext.Movies;

        // public IQueryable<Category> Categories => throw new NotImplementedException();

        public void AddMovie(Movie movie)
        {
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();
        }

        public void DeleteMovie(int id)
        {
            var result = _movieContext.Movies.Where(i => i.MovieId == id).FirstOrDefault();
            if (result != null)
            {
                _movieContext.Movies.Remove(result);
                _movieContext.SaveChanges();

            }

        }

        public IEnumerable<Movie> GetMoviesByCategory(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovies(MovieViewModel model, int catid, string imageFile)
        {
            if (imageFile == string.Empty)
            {
                var entity = _movieContext.Movies.FirstOrDefault(i => i.MovieId == model.MovieId);
                if (entity != null)
                {
                    entity.MovieId = model.MovieId;
                    entity.MovieName = model.MovieName;

                    entity.Year = model.Year;
                    entity.MovieDescription = model.MovieDescription;
                    entity.CategoryId = catid;
                    _movieContext.SaveChanges();
                }
            }
            else
            {
                var entity = _movieContext.Movies.FirstOrDefault(i => i.MovieId == model.MovieId);
                if (entity != null)
                {
                    entity.MovieId = model.MovieId;
                    entity.MovieName = model.MovieName;
                    entity.ImageName = imageFile;
                    entity.Year = model.Year;
                    entity.MovieDescription = model.MovieDescription;
                    entity.CategoryId = catid;
                    _movieContext.SaveChanges();
                }
            }
        }

        public void UpdateMovie(int id)
        {
            throw new NotImplementedException();
        }
    }
}