using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.BLL.Contracts;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Implementation
{
    public class PictureService:IPictureService
    {
        private IPictureDAL PictureDAL { get; }
        
        public PictureService(IPictureDAL pictureDAL)
        {
            this.PictureDAL = pictureDAL;
        }
        
        public async Task<Picture> CreateAsync(PictureUpdateModel picture) {
            return await this.PictureDAL.InsertAsync(picture);
        }
        
        public async Task<Picture> UpdateAsync(PictureUpdateModel picture) {
            return await this.PictureDAL.UpdateAsync(picture);
        }
        
        public Task<IEnumerable<Picture>> GetAsync() {
            return this.PictureDAL.GetAsync();
        }
        
        public Task<Picture> GetAsync(IPictureIdentity id)
        {
            return this.PictureDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IPictureContainer pictureContainer)
        {
            if (pictureContainer == null)
            {
                throw new ArgumentNullException(nameof(pictureContainer));
            }
            if (pictureContainer.PictureId.HasValue )
            {
                var department = await this.PictureDAL.GetAsync(new PictureIdentityModel(pictureContainer.PictureId.Value));
                if(department == null)
                    throw new InvalidOperationException($"Picture not found by id {pictureContainer.PictureId}");
            }
        }
    }
}