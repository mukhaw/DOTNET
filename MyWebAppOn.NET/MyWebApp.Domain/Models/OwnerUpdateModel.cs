using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class OwnerUpdateModel:BaseOwner, IOwnerIdentity
    {
        public int Id { get; set; }
    }
}