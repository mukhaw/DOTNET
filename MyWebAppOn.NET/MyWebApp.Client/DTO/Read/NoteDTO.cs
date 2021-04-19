using System;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Domain;

namespace MyWebApp.Client.DTO.Read
{
    public class NoteDTO
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int DiseaseId { get; set; }
        
        public DateTime DateVisit { get; set; }
    }
}