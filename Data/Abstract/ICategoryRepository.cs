using Film.Models;

namespace Film.Data.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> categories { get; }
        void Addcategory(Category category);
        void Deletecategory(int id);
        void Updatecategory(int id, Category category);
        IEnumerable<Category> GetCategoriesByid(int id);

    }
}