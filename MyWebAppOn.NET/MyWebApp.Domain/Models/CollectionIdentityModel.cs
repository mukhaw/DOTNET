using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class CollectionIdentityModel:ICollectionIdentity
    {
        public int Id { get; }

        public CollectionIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}