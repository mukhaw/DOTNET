using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface IByerService
    {
        Task<IEnumerable<Byer>> GetAsync();
        Task<Byer> GetAsync(IByerIdentity id);
        Task<Byer> CreateAsync(ByerUpdateModel patient);
        Task<Byer> UpdateAsync(ByerUpdateModel patient);
        Task ValidateAsync(IByerContainer ByerContainer);
    }
}