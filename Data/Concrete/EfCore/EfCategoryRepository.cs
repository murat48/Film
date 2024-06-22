using Film.Data.Abstract;
using Film.Models;

namespace Film.Data.Concrete.EntityFrameworkCore
{
    public class EfCategoryRepository : ICategoryRepository
    {
        private MovieContext _movieContext;
        public EfCategoryRepository(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public IQueryable<Category> categories => _movieContext.Category;

        public void Addcategory(Category category)
        {
            _movieContext.Category.Add(category);
            _movieContext.SaveChanges();
        }

        public void Deletecategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetCategoriesByid(int id)
        {
            throw new NotImplementedException();
        }

        public void Updatecategory(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }

}