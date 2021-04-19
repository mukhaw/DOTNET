using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetNote();
        Task<Note> GetNote(int id);
        Task<Note> PutNote(Note note);
        Task<Note> PatchNote(Note note);
    }
}