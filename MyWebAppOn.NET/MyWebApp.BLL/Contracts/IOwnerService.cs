using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MyWebApp.Domain;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;

namespace MyWebApp.BLL.Contracts
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetAsync();
        Task<Owner> GetAsync(IOwnerIdentity id);
        Task<Owner> CreateAsync(OwnerUpdateModel owner);
        Task<Owner> UpdateAsync(OwnerUpdateModel owner);
        Task ValidateAsync(IOwnerContainer ownerContainer);
    }
}