using MyWebApp.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebApp.DAL.Contracts;
using MyWebApp.Domain.Contracts;
using MyWebApp.Domain.Models;
using Disease = MyWebApp.DAL.Entity.Disease;

namespace MyWebApp.DAL.Implementations
{
    public class PictureDAL:IPictureDAL
    {
        private AppContext Context { get; }
        private IMapper Mapper { get; }
        
        public PictureDAL(AppContext context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }

        public async Task<MyWebApp.Domain.Picture> InsertAsync(PictureUpdateModel picture)
        {
            var result = await this.Context.AddAsync(this.Mapper.Map<Picture>(picture));

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Picture>(result.Entity);
        }

        public async Task<IEnumerable<MyWebApp.Domain.Picture>> GetAsync()
        {
            return this.Mapper.Map<IEnumerable<MyWebApp.Domain.Picture>>(
                await this.Context.Picture.ToListAsync());
        }

        public async Task<MyWebApp.Domain.Picture> GetAsync(IPictureIdentity picture)
        {
            var result = await this.Get(picture);

            return this.Mapper.Map<MyWebApp.Domain.Picture>(result);
        }

        private async Task<Picture> Get(IPictureIdentity picture)
        {
            if (picture == null)
            {
                throw new ArgumentNullException(nameof(picture));
            }
            
            return await this.Context.Picture.FirstOrDefaultAsync(x => x.Id == picture.Id);
        }

        public async Task<MyWebApp.Domain.Picture> UpdateAsync(PictureUpdateModel picture)
        {
            var existing = await this.Get(Picture);

            var result = this.Mapper.Map(picture, existing);

            this.Context.Update(result);

            await this.Context.SaveChangesAsync();

            return this.Mapper.Map<MyWebApp.Domain.Picture>(result);
        }
    }
}