using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class ByerController : Controller
    {
        private IByerService ByerService { get; }
        private IPictureService PictureService { get; }
        public ByerController(IByerService byerService, IPictureService pictureService)
        {
            ByerService = byerService;
            PictureService = pictureService;
        }
        public async  Task<IActionResult> List()
        {
            return View(await this.ByerService.GetByer());
        }
      
        public async Task<IActionResult> AddPicture()
        {
            return View(await  this.PictureService.GetPicture());
        }

        [HttpPost]
        public async Task<IActionResult> Put(Byer byer)
        {
            System.Console.WriteLine(" fdfsdf"  + byer.PictureId);
            await this.ByerService.PutByer(byer);
            return RedirectToAction("List");
        }
    }
}