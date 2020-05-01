using System.ComponentModel.DataAnnotations;

namespace EllAid.Dashboard.UI.MVC.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}