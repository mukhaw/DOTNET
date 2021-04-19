using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class NoteController : Controller
    {
        // GET
        private INoteService NoteService { get; }
        private IByerService ByerService { get; }
        private IOwnerService OwnerService { get; }
        private IPictureService PictureService { get; }
        
        public NoteController(INoteService noteService, IByerService byerService, IOwnerService ownerService, IPictureService pictureService)
        {
            NoteService = noteService;
            ByerService = byerService;
            OwnerService = ownerService;
            PictureService = pictureService;
        }

        public async Task<IActionResult> Notes()
        {
            
            return View(await this.NoteService.GetNote());
        }

        [HttpGet]
        public async Task<IActionResult> AddNote()
        {
            return View(new HelpObjects(await  this.ByerService.GetByer(),
                await  this.OwnerService.GetOwner(),
                await this.PictureService.GetPicture()));
        }
        [HttpPost]
        public async Task<IActionResult> Put(Note note)
        {
            await this.NoteService.PutNote(note);
            //Console.Out.WriteLine(note);
            return RedirectToAction("Notes");
        }
    }
}