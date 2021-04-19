using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Client.DTO.Create
{
    public class OwnerCreateDTO
    {
        [Required(ErrorMessage = "Initials is required")]
        public string Initials { get; set; }
        public string Collection { get; set; }
    }
}