using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface IPictureService
    {
        Task<IEnumerable<Picture>> GetAsync();
        Task<Picture> GetAsync(IPictureIdentity id);
        Task<Picture> CreateAsync(PictureUpdateModel picture);
        Task<Picture> UpdateAsync(PictureUpdateModel picture);
        Task ValidateAsync(IPictureContainer pictureContainer);
    }
}