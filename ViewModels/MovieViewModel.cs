using Film.Models;

namespace Film.ViewModels
{
    public class MovieViewModel
    {
        public int MovieId { get; set; }

        public string MovieName { get; set; } = string.Empty;
        public int Year { get; set; }
        public string MovieDescription { get; set; } = string.Empty;
        public string? ImageName { get; set; }
        public int? CategoryId { get; set; }

        public List<Category> Category { get; set; } = new();

    }
}