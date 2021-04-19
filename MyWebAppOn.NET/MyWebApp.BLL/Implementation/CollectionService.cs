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
    public class CollectionService:ICollectionService
    {
        private ICollectionDAL CollectionDAL { get; }
        
        public CollectionService(ICollectionDAL CollectionDAL)
        {
            this.CollectionDAL = CollectionDAL;
        }
        
        public async Task<Collection> CreateAsync(CollectionUpdateModel collection) {
            return await this.CollectionDAL.InsertAsync(collection);
        }
        
        public async Task<Collection> UpdateAsync(CollectionUpdateModel collection) {
            return await this.CollectionDAL.UpdateAsync(collection);
        }
        
        public Task<IEnumerable<Collection>> GetAsync() {
            return this.CollectionDAL.GetAsync();
        }
        
        public Task<Collection> GetAsync(ICollectionIdentity id)
        {
            return this.CollectionDAL.GetAsync(id);
        }
        public async Task ValidateAsync(ICollectionContainer collectionContainer){
            if (collectionContainer == null)
            {
                throw new ArgumentNullException(nameof(collectionContainer));
            }
            else
            {
                if (collectionContainer.collectionId.HasValue)
                {
                    var department = await this.collectionDAL.GetAsync(new CollectionIdentityModel(collectionContainer.CollectionId.Value));
                    if (department == null)
                        throw new InvalidOperationException($"Collection not found by id {collectionContainer.CollectionId}");
                }
            }
        }
    }
}