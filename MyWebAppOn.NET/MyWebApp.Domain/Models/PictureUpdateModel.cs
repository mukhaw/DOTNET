using MyWebApp.Domain.Base;
using MyWebApp.Domain.Contracts;

namespace MyWebApp.Domain.Models
{
    public class PictureUpdateModel: BasePicture, IPictureIdentity
    {
        public int Id { get; set; }
    }
}