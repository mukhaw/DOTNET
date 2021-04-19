using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class OwnerIdentityModel:IOwnerIdentity
    {
        public int Id { get; }

        public OwnerIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}