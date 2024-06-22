using System.ComponentModel.DataAnnotations;

namespace Film.ViewModels
{
    public class CategoryViewModel
    {

        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }

}