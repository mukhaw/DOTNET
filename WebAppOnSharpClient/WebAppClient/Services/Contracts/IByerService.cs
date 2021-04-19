using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClient.Models;

namespace WebAppClient.Services.Contracts
{
    public interface IByerService
    {
        Task<IEnumerable<Byer>> GetByer();
        Task<Byer> GetByer(int id);
        Task<Byer> PutByer(Byer byer);
        Task<Byer> PatchByer(Byer byer);
    }
}