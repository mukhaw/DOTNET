using MyWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Street = MyWebApp.DAL.Entity.Street;

namespace MyWebApp.DAL.Implementations
{
    public class CollectionDAL:ICollectionDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public StreetDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Collection> InsertAsync(CollectionUpdateModel collection)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Collection>(collection));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Collection>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Collection>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Collection>>(
                await this.Context.Collection.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Collection> GetAsync(ICollectionIdentity collection)
        {
            var result = await this.Get(collection);

            return this.Mapper.Map<MyWebApp.Domain.Collection>(result);
        }

        private async Task<Collection> Get(ICollectionIdentity collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            
            return await this.Context.Collection.FirstOrDefaultAsync(x => x.Id == collection.Id);
        }

        public async Task<MyWebApp.Domain.Collection> UpdateAsync(CollectionUpdateModel collection)
        {
            var existing = await this.Get(collection);

            var result = this.Mapper.Map(collection, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Collection>(result);
        }
    }
}