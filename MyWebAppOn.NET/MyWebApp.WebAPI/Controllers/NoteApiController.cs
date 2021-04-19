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
    [Route("api/note")]
    public class NoteApiController:ControllerBase
    {
        private INoteService NoteService{ get;}
        private ILogger<NoteApiController> Logger { get; }
        private IMapper Mapper { get; }
        
        
        public NoteApiController(ILogger<NoteApiController> logger, IMapper mapper, INoteService noteService)
        {
            this.Logger = logger;
            this.NoteService = noteService;
            this.Mapper = mapper;
        }
        
        [HttpGet]
        public async Task<IEnumerable<NoteDTO>> GetAsync()
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called ");
            return this.Mapper.Map<IEnumerable<NoteDTO>>(await this.NoteService.GetAsync());
        }
        
        [HttpGet("{noteId}")]
        public async Task<NoteDTO> GetAsync(int noteId)
        {
            this.Logger.LogTrace($"{nameof(this.GetAsync)} called for {noteId}");
            return this.Mapper.Map<NoteDTO>(await this.NoteService.GetAsync(new NoteIdentityModel(noteId)));
        }
        
        [HttpPatch]
        public async Task<NoteDTO> PatchAsync(NoteUpdateDTO note)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.NoteService.UpdateAsync(this.Mapper.Map<NoteUpdateModel>(note));
            return this.Mapper.Map<NoteDTO>(result);
        }
        
        [HttpPut]
        public async Task<NoteDTO> PutAsync(NoteCreateDTO note)
        {
            this.Logger.LogTrace($"{nameof(this.PutAsync)} called");
            var result = await this.NoteService.CreateAsync(this.Mapper.Map<NoteUpdateModel>(note));
            return this.Mapper.Map<NoteDTO>(result);
        }
    }
}