using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface IPictureDAL
    {
        Task<Picture> InsertAsync(PictureUpdateModel picture);
        Task<IEnumerable<Picture>> GetAsync();
        Task<Picture> GetAsync(IPictureIdentity pictureId);
        Task<Picture> UpdateAsync(PictureUpdateModel picture);
    }
}