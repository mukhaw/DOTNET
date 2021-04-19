using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Patient = MyWebApp.DAL.Entity.Patient;

namespace MyWebApp.DAL.Implementations
{
    public class ByerDAL:IByerDAL 
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public ByerDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Byer> InsertAsync(ByerUpdateModel byer)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Patient>(byer));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Byer>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Byer>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Byer>>(
                await this.Context.Byer.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Byer> GetAsync(IPatientIdentity byer)
        {
            var result = await this.Get(byer);

            return this.Mapper.Map<MyWebApp.Domain.Byer>(result);
        }

        private async Task<Byer> Get(IByerIdentity byer)
        {
            if (byer == null)
            {
                throw new ArgumentNullException(nameof(byer));
            }
            
            return await this.Context.Byer.FirstOrDefaultAsync(x => x.Id == byer.Id);
        }

        public async Task<MyWebApp.Domain.Byer> UpdateAsync(ByerUpdateModel byer)
        {
            var existing = await this.Get(byer);

            var result = this.Mapper.Map(byer, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Byer>(result);
        }
    }
}