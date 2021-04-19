using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetOwner();
        Task<Owner> GetOwner(int id);
        Task<Owner> PutOwner(Owner owner);
        Task<Owner> PatchOwner(Owner owner);
    }
}