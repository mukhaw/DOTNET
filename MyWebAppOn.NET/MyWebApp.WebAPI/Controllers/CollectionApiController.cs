using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.BLL.Contracts;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Update;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/collection")]
    public class CollectionApiController: ControllerBase
    {
        private ICollectionService CollectionService{ get;}
        private ILogger<CollectionApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public CollectionApiController(ILogger<CollectionApiController> logger, IMapper mapper, ICollectionService collectionService)
        {
            this.Logger = logger;
            this.CollectionService = collectionService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<CollectionDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<CollectionDTO>>(await this.CollectionService.GetAsync());
        }
        
        [HttpGet("{collectionId}")]
        public async Task<CollectionDTO> GetAsync(int collectionId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {collectionId}");
            return this.Mapper.Map<CollectionDTO>(await this.CollectionService.GetAsync(new CollectionIdentityModel(collectionId)));
        }
        
        [HttpPatch]
        public async Task<CollectionDTO> PatchAsync(CollectionUpdateDTO collection)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.CollectionService.UpdateAsync(this.Mapper.Map<CollectionUpdateModel>(collection));
            return this.Mapper.Map<CollectionDTO>(result);
        }
        
        [HttpPut]
        public async Task<CollectionDTO> PutAsync(CollectionCreateDTO collection)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.CollectionService.CreateAsync(this.Mapper.Map<CollectionUpdateModel>(collection));
            return this.Mapper.Map<CollectionDTO>(result);
        }
    }
}