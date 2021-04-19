using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.DAL.Contracts
{
    public interface IOwnerDAL
    {
        Task<Owner> InsertAsync(OwnerUpdateModel owner);
        Task<IEnumerable<Owner>> GetAsync();
        Task<Owner> GetAsync(IOwnerIdentity ownerId);
        Task<Owner> UpdateAsync(OwnerUpdateModel owner);
    }
}