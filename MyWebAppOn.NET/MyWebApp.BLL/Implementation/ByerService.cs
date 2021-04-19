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
    public class ByerService: IByerService
    {
        private IByerDAL ByerDAL { get; }
        private IByerService ByerService { get; }
        
        public ByerService(IByerDAL byerDAL, IPictureService pictureService)
        {
            this.ByerDAL = byerDAL;
            this.PictureService = pictureService;
        }
        
        public async Task<Byer> CreateAsync(ByerUpdateModel byer) {
            await this.PictureService.ValidateAsync(byer);
            return await this.ByerDAL.InsertAsync(byer);
        }
        
        public async Task<Byer> UpdateAsync(ByerUpdateModel byer) {
            await this.ByerService.ValidateAsync(byer);
            return await this.ByerDAL.UpdateAsync(byer);
        }
        
        public Task<IEnumerable<Byer>> GetAsync() {
            return this.ByerDAL.GetAsync();
        }
        
        public Task<Byer> GetAsync(IByerIdentity id)
        {
            return this.ByerDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IByerContainer byerContainer)
        {
            if (byerContainer == null)
            {
                throw new ArgumentNullException(nameof(byerContainer));
            }
            if (byerContainer.ByerId.HasValue)
            {
                var department = await this.ByerDAL.GetAsync(new ByerIdentityModel(byerContainer.ByerId.Value));
                if( department == null)
                    throw new InvalidOperationException($"Byer not found by id {byerContainer.ByerId}");
            }
        }
    }
}