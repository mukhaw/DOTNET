using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyWebApp.BLL.Contracts;
using MyWebApp.Client.DTO.Create;
using MyWebApp.Client.DTO.Read;
using MyWebApp.Client.DTO.Update;
using MyWebApp.Domain.Models;

namespace MyWebApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/picture")]
    public class PictureApiController: ControllerBase
    {
        private IPictureService PictureService{ get;}
        private ILogger<PictureApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public PictureApiController(ILogger<PictureApiController> logger, IMapper mapper, IPictureService pictureService)
        {
            this.Logger = logger;
            this.PictureService = pictureService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<PictureDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<PictureDTO>>(await this.PictureService.GetAsync());
        }
        
        [HttpGet("{PictureId}")]
        public async Task<PictureDTO> GetAsync(int pictureId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {diseaseId}");
            return this.Mapper.Map<PictureDTO>(await this.PictureService.GetAsync(new PictureIdentityModel(pictureId)));
        }
        
        [HttpPatch]
        public async Task<PictureDTO> PatchAsync(PictureUpdateDTO picture)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.PictureService.UpdateAsync(this.Mapper.Map<PictureUpdateModel>(picture));
            return this.Mapper.Map<PictureDTO>(result);
        }
        
        [HttpPut]
        public async Task<PictureDTO> PutAsync(PictureCreateDTO picture)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.PictureService.CreateAsync(this.Mapper.Map<PictureUpdateModel>(picture));
            return this.Mapper.Map<PictureDTO>(result);
        }
    }
}