using System.ComponentModel.DataAnnotations;

namespace JoaoLuizDeveloper.Domain.Entity
{
    public class Resume : BaseEntity
    {
        [Required(ErrorMessage = "You must to set a Title for Resume."),
         MinLength(3, ErrorMessage = "Minimum 3 characters by Title"), 
         MaxLength(50, ErrorMessage = "Maximum 50 characters by Title")]
        public string Title { get; set; }
        [MinLength(3, ErrorMessage = "Minimum 3 characters by Description"),
         MaxLength(1000, ErrorMessage = "Maximum 1000 characters by Description")]
        public string? Description { get; set; }
    }
}