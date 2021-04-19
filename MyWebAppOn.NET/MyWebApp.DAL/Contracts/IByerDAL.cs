using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Patient = MyWebApp.Domain.Patient;

namespace MyWebApp.DAL.Contracts
{
    public interface IByerDAL
    {
        Task<Byer> InsertAsync(ByerUpdateModel byer);
        Task<IEnumerable<Byer>> GetAsync();
        Task<Byer> GetAsync(IByerIdentity byerId);
        Task<Byer> UpdateAsync(byerUpdateModel byer);
    }
}