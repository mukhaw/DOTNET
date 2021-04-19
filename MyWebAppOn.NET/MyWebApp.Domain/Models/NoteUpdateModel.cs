using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class NoteUpdateModel:BaseNote, INoteIdentity, IByerContainer,IOwnerContainer, IPictureContainer
    {
        public int Id { get; set; }
        
    }
}