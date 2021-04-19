using MyWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Note = MyWebApp.DAL.Entity.Note;

namespace MyWebApp.DAL.Implementations
{
    public class NoteDAL:INoteDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public NoteDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Note> InsertAsync(NoteUpdateModel note)
        {
            Note new_obj = this.Mapper.Map<Note>(note);
            new_obj.DateVisit = DateTime.Today;
            var result = await this.Context.AddAsync(new_obj);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Note>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Note>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Note>>(
                await this.Context.Note.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Note> GetAsync(INoteIdentity note)
        {
            var result = await this.Get(note);

            return this.Mapper.Map<MyWebApp.Domain.Note>(result);
        }

        private async Task<Note> Get(INoteIdentity note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }
            
            return await this.Context.Note.FirstOrDefaultAsync(x => x.Id == note.Id);
        }

        public async Task<MyWebApp.Domain.Note> UpdateAsync(NoteUpdateModel note)
        {
            var existing = await this.Get(note);
            
            var result = this.Mapper.Map(note, existing);
            
            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Note>(result);
        }
    }
}