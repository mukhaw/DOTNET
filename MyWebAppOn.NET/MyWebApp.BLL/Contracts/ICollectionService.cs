using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface ICollectionService
    {
        Task<IEnumerable<Collection>> GetAsync();
        Task<Collection> GetAsync(ICollectionIdentity id);
        Task<Collection> CreateAsync(CollectionUpdateModel collection);
        Task<Collection> UpdateAsync(CollectionUpdateModel collection);
        Task ValidateAsync(ICollectionContainer collectionContainer);
    }
}