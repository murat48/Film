using Film.Data.Abstract;
using Film.Models;
using Film.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Film.Controllers
{
    public class AdminController : Controller
    {
        private ICategoryRepository _categoryRepository;
        private IMovieRepository _movieRepository;
        public AdminController(ICategoryRepository categoryRepository, IMovieRepository movieRepository)
        {
            _categoryRepository = categoryRepository;
            _movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Addcategory(new Category
                {
                    CategoryName = model.CategoryName

                });
                return RedirectToAction("CreateCategory");
            }
            return View(model);
        }
        public async Task<IActionResult> List()
        {
            var moviese = _movieRepository.Movies;
            return View(await moviese.ToListAsync());
        }
        public IActionResult Edit(int? id)
        {

            var result = _movieRepository.Movies.Include(i => i.Category).FirstOrDefault(i => i.MovieId == id);


            if (result == null)
            {
                return NotFound();
            }
            List<Category> sdsds = new List<Category>();
            if (result.Category != null)
            {
                sdsds.Add(result.Category);
            }
            ViewBag.categories = _categoryRepository.categories.ToList();


            return View(new MovieViewModel
            {

                MovieId = result.MovieId,
                MovieName = result.MovieName,
                MovieDescription = result.MovieDescription,
                Year = result.Year,
                ImageName = result.ImageName,
                CategoryId = result.CategoryId,
                Category = sdsds


            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MovieViewModel model, int CategoryId, IFormFile? imageFile)
        {
            if (ModelState.IsValid)
            {

                var extension = "";
                var randomFileName = "";
                if (imageFile != null)
                {
                    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                    extension = Path.GetExtension(imageFile.FileName);

                    if (!allowedExtensions.Contains(extension))
                    {
                        ModelState.AddModelError("", "Geçerli bir resim seçiniz.");
                    }
                    randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                }

                _movieRepository.UpdateMovies(model, CategoryId, randomFileName);

            }
            return RedirectToAction("List", "Admin");
        }
        public IActionResult AddMovie()
        {
            ViewBag.Category = _categoryRepository.categories.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var movi = _movieRepository.Movies.Where(i => i.MovieId == id);

            if (movi != null)
            {
                _movieRepository.DeleteMovie(id);
            }

            return RedirectToAction("List", "Admin");
        }
        // , int[] catIds
        [HttpPost]
        public async Task<IActionResult> AddMovie(Movie model, IFormFile imageFile)
        {
            var extension = "";
            if (imageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                extension = Path.GetExtension(imageFile.FileName);

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Geçerli bir resim seçiniz.");
                }
            }
            if (ModelState.IsValid)
            {

                if (imageFile != null)
                {
                    var randomFileName = string.Format($"{Guid.NewGuid().ToString()}{extension}");
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }



                    _movieRepository.AddMovie(new Movie
                    {
                        MovieName = model.MovieName,
                        MovieDescription = model.MovieDescription,
                        Year = model.Year,
                        ImageName = randomFileName,
                        CategoryId = model.CategoryId


                    });
                    return RedirectToAction("List");
                }

            }

            return View(model);
        }
    }
}