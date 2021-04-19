using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IPictureService
    {
        Task<IEnumerable<Picture>> GetPicture();
        Task<Picture> GetPicture(int id);
        Task<Picture> PutPicture(Picture picture);
        Task<Picture> PatchPicture(Picture picture);
    }
}