using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class ByerIdentityModel:IByerIdentity
    {
        public int Id { get; }

        public ByerIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}