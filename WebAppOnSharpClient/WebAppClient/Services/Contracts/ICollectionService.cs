using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface ICollectionService
    {
        Task<IEnumerable<Collection>> GetCollection();
        Task<Street> GetCollection(int id);
        Task<Street> PutCollection(Collection collection );
        Task<Street> PatchCollection(Collection collection);
    }
}