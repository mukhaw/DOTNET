using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAsync();
        Task<Note> GetAsync(INoteIdentity id);
        Task<Note> CreateAsync(NoteUpdateModel note);
        Task<Note> UpdateAsync(NoteUpdateModel note);
    }
}