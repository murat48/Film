using Film.Data.Abstract;
using Film.Models;
using Film.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Film.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IMovieRepository _movieRepository;
        public HomeController(ICategoryRepository categoryRepository, IMovieRepository movieRepository)
        {
            _categoryRepository = categoryRepository;
            _movieRepository = movieRepository;
        }
        public async Task<IActionResult> Index()
        {
            //var movie = await _movieRepository.Movies.ToListAsync();
            return View(new MovieModel { Moviess = await _movieRepository.Movies.OrderByDescending(p => p.MovieId).ToListAsync() });
        }
        public async Task<IActionResult> Detail(int? id)
        {
            var movies = _movieRepository.Movies.Where(p => p.MovieId == id).FirstOrDefault();
            int categoryid = Convert.ToInt32(movies?.CategoryId);

            var rsq = _movieRepository.Movies.Where(p => p.CategoryId == categoryid).ToList();

            //  ViewBag.Category
            var cat = await _movieRepository.Movies.Where(p => p.CategoryId == categoryid).ToListAsync();
            if (movies != null)
            {
                cat.Remove(movies);
            }
            ViewBag.Category = cat;
            ViewBag.Cnt = Convert.ToInt32(cat.Count());
            return View(new MovieModel { Moviess = await _movieRepository.Movies.Where(p => p.MovieId == id).ToListAsync() });


        }
    }

}
