using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class PictureIdentityModel:IPictureIdentity
    {
        public int Id { get; }

        public PictureIdentityModel(int id)
        {
            this.Id = id;
        }
    }
}