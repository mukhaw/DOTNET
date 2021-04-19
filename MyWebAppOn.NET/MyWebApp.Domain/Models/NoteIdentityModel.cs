using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class NoteIdentityModel:INoteIdentity
    {
        public int Id { get; }

        public NoteIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}