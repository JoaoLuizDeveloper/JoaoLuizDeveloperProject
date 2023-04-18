using System.ComponentModel.DataAnnotations;

namespace JoaoLuizDeveloper.Domain.Entity
{
    public class ContactUs : BaseEntity
    {
        [Required(ErrorMessage = "You must to set a Subject for Contact Us."),
         MinLength(3, ErrorMessage = "Minimum 3 characters by Subject"), 
         MaxLength(50, ErrorMessage = "Maximum 50 characters by Subject")]
        public string Subject { get; set; }        
        [Required(ErrorMessage = "You must to set a Email for Contact Us."), EmailAddress(ErrorMessage = "The Email is wrong")]
        public string Email { get; set; }        
        [Phone(ErrorMessage = "The Phone is wrong")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "You must to set a Description for Contact Us."),
         MinLength(3, ErrorMessage = "Minimum 3 characters by Description"),
         MaxLength(1000, ErrorMessage = "Maximum 1000 characters by Description")]
        public string? Description { get; set; }
        public string? file { get; set; }        
    }
}