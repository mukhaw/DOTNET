using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.BLL.Contracts;
using MyWebApp.Client.DTO;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Read;
using MyWebApp.Client.DTO.Update;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/byer")]
    public class ByerApiController : ControllerBase
    {
        private IByerService ByerService{ get;}
        private ILogger<ByerApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public ByerApiController(ILogger<ByerApiController> logger, IMapper mapper, IByerService byerService)
        {
            this.Logger = logger;
            this.ByerService =byerService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<ByerDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<ByerDTO>>(await this.ByerService.GetAsync());
        }
        
        [HttpGet("{byerId}")]
        public async Task<ByerDTO> GetAsync(int byerId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {byerId}");
            return this.Mapper.Map<ByerDTO>(await this.ByerService.GetAsync(new ByerIdentityModel(byerId)));
        }
        
        [HttpPatch]
        public async Task<ByerDTO> PatchAsync(ByerUpdateDTO byer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.ByerService.UpdateAsync(this.Mapper.Map<ByerUpdateModel>(byer));
            return this.Mapper.Map<ByerDTO>(result);
        }
        
        [HttpPut]
        public async Task<ByerDTO> PutAsync(ByerCreateDTO byer)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.ByerService.CreateAsync(this.Mapper.Map<ByerUpdateModel>(byer));
            return this.Mapper.Map<ByerDTO>(result);
        }
    }
}