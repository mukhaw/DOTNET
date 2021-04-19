using MyWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Doctor = MyWebApp.DAL.Entity.Doctor;


namespace MyWebApp.DAL.Implementations
{
    public class OwnerDAL:IOwnerDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public OwnerDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Owner> InsertAsync(OwnerUpdateModel owner)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Owner>(owner));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Doctor>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Owner>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Owner>>(
                await this.Context.Owner.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Owner> GetAsync(IOwnerIdentity owner)
        {
            var result = await this.Get(owner);

            return this.Mapper.Map<MyWebApp.Domain.Owner>(result);
        }

        private async Task<Owner> Get(IOwnerIdentity owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }
            
            return await this.Context.Owner.FirstOrDefaultAsync(x => x.Id == owner.Id);
        }

        public async Task<MyWebApp.Domain.Owner> UpdateAsync(OwnerUpdateModel owner)
        {
            var existing = await this.Get(owner);

            var result = this.Mapper.Map(owner, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Owner>(result);
        }
    }
}