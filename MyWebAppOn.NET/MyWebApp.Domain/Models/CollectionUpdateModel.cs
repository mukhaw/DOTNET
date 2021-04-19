using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class CollectionUpdateModel:BaseCollection, ICollectionIdentity
    {
        public int Id { get; set; }
    }
}