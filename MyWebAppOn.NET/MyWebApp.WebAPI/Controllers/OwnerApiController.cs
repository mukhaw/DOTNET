using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.BLL.Contracts;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Read;
using MyWebApp.Client.DTO.Update;
using MyWebApp.DAL;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/owner")]
    public class OwnerApiController : ControllerBase
    {
        private IOwnerService OwnerService{ get;}
        private ILogger<OwnerApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public OwnerApiController(ILogger<OwnerApiController> logger, IMapper mapper, IOwnerService ownerService)
        {
            this.Logger = logger;
            this.OwnerService = ownerService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<OwnerDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for ");
            return this.Mapper.Map<IEnumerable<OwnerDTO>>(await this.OwnerService.GetAsync());
        }
        
        [HttpGet("{ownerId}")]
        public async Task<OwnerDTO> GetAsync(int ownerId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called");
            return this.Mapper.Map<OwnerDTO>(await this.OwnerService.GetAsync(new OwnerIdentityModel(ownerId)));
        }
        
        [HttpPatch]
        public async Task<OwnerDTO> PatchAsync(OwnerUpdateDTO owner)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.OwnerService.UpdateAsync(this.Mapper.Map<OwnerUpdateModel>(owner));
            return this.Mapper.Map<OwnerDTO>(result);
        }
        
        [HttpPut]
        public async Task<OwnerDTO> PutAsync(OwnerCreateDTO owner)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.OwnerService.CreateAsync(this.Mapper.Map<OwnerUpdateModel>(owner));
            return this.Mapper.Map<OwnerDTO>(result);
        }
    }
}