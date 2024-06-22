namespace Film.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; } = string.Empty;
        public int Year { get; set; }
        public string MovieDescription { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public Category? Category { get; set; }
        public int? CategoryId { get; set; }

        // public List<Category> Categorys { get; set; } = new List<Category>();

    }
}