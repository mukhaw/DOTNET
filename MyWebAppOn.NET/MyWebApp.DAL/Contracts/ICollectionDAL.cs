using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface ICollectionDAL
    {
        Task<Collection> InsertAsync(CollectionUpdateModel collection);
        Task<IEnumerable<Collection>> GetAsync();
        Task<Collection> GetAsync(ICollectionIdentity collectionId);
        Task<Collection> UpdateAsync(CollectionUpdateModel collection);
    }
}