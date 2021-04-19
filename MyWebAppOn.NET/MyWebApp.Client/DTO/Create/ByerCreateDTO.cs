using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Client.DTO.Create
{
    public class ByerCreateDTO
    {
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        
        public string MiddleName { get; set; }
        
        [Required(ErrorMessage = "Passport is required")]
        public string PassportNumber{ get; set; }
        [Required(ErrorMessage = "PictureID is required")]
        public int PictureId { get; set; }
    }
}