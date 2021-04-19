using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain
{
    public class Byer:BasePatient,IByerContainer
    {
        
        public int Id { get; set; }
        public int? PictureId { get; set; }
    }
}