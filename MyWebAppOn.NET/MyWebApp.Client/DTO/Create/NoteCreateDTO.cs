using System.ComponentModel.DataAnnotations;
using MyWebApp.Domain;

namespace MyWebApp.Client.DTO.Create
{
    public class NoteCreateDTO
    {
        [Required(ErrorMessage = "DoctorId is required")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "PatientId is required")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "DiseaseId is required")]
        public int DiseaseId { get; set; }
    }
}