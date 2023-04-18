using System.ComponentModel.DataAnnotations;

namespace JoaoLuizDeveloper.Domain.Entity
{
    public class NewsLetter : BaseEntity
    {
        [Required(ErrorMessage = "You must to set a Title for NewsLetter."),
         MinLength(3, ErrorMessage = "Minimum 3 characters by Title"), 
         MaxLength(100, ErrorMessage = "Maximum 100 characters by Title")]
        public string Title { get; set; }
        [MinLength(3, ErrorMessage = "Minimum 3 characters by Description"),
         MaxLength(100, ErrorMessage = "Maximum 10000 characters by Description")]
        public string? Description { get; set; }
        public string Image { get; set; } = String.Empty;
        public string Url { get; set; }
    }
}