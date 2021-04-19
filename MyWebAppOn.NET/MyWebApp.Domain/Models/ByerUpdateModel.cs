using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class ByerUpdateModel: BaseByer, IByerIdentity, IPictureContainer
    {
        public int Id { get; set; }
        public int? StreetId { get; set; }
    }
}