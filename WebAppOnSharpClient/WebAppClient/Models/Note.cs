using System;

namespace WebAppClient.Models
{
    public class Note
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int? DiseaseId { get; set; }
        public DateTime DateVisit { get; set; }
    }
}