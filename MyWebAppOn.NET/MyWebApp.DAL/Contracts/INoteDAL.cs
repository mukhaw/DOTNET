using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface INoteDAL
    {
        Task<Note> InsertAsync(NoteUpdateModel note);
        Task<IEnumerable<Note>> GetAsync();
        Task<Note> GetAsync(INoteIdentity noteId);
        Task<Note> UpdateAsync(NoteUpdateModel note);
    }
}