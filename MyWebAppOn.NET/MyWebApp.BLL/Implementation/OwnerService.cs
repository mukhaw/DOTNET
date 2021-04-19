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
    public class OwnerService:IOwnerService
    {
        private IOwnerDAL OwnerDAL { get; }
        
        public OwnerService(IOwnerDAL ownerDAL)
        {
            this.OwnerDAL = ownerDAL;
        }
        
        public async Task<Owner> CreateAsync(OwnerUpdateModel owner) {
            return await this.OwnerDAL.InsertAsync(owner);
        }
        
        public async Task<Owner> UpdateAsync(OwnerUpdateModel owner) {
            return await this.OwnerDAL.UpdateAsync(owner);
        }
        
        public Task<IEnumerable<Owner>> GetAsync() {
            return this.OwnerDAL.GetAsync();
        }
        
        public Task<Owner> GetAsync(IOwnerIdentity id)
        {
            return this.OwnerDAL.GetAsync(id);
        }
        
        public async Task ValidateAsync(IOwnerContainer ownerContainer)
        {
            if (ownerContainer == null)
            {
                throw new ArgumentNullException(nameof(ownerContainer));
            }
     
            if (ownerContainer.OwnerId.HasValue)
            {
                var department = await this.OwnerDAL.GetAsync(new OwnerIdentityModel((int) ownerContainer.OwnerId));
                if(department == null) 
                    throw new InvalidOperationException($"Owner not found by id {ownerContainer.OwnerId}");
            }
        }
    }
}