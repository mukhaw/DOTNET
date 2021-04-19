using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.BLL.Contracts;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Implementation
{
    public class NoteService:INoteService
    {
        private INoteDAL NoteDAL { get; }
        private IPatientService PatientService { get; }
        private IDoctorService DoctorService { get; }
        private IDiseaseService DiseaseService { get; }
        public NoteService(INoteDAL noteDAL, IPatientService patientService, IDoctorService doctorService, IDiseaseService diseaseService)
        {
            this.NoteDAL = noteDAL;
            this.PatientService = patientService;
            this.DoctorService = doctorService;
            this.DiseaseService = diseaseService;
        }
        
        public async Task<Note> CreateAsync(NoteUpdateModel note) {
            await this.PatientService.ValidateAsync(note);
            await this.DoctorService.ValidateAsync(note);
            await this.DiseaseService.ValidateAsync(note);
            return await this.NoteDAL.InsertAsync(note);
        }
        
        public async Task<Note> UpdateAsync(NoteUpdateModel note) {
            return await this.NoteDAL.UpdateAsync(note);
        }
        
        public Task<IEnumerable<Note>> GetAsync() {
            return this.NoteDAL.GetAsync();
        }
        
        public Task<Note> GetAsync(INoteIdentity id)
        {
            return this.NoteDAL.GetAsync(id);
        }
    }
}