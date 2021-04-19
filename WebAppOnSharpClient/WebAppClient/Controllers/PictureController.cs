using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class PictureController:Controller
    {
        private IPictureService PictureService { get; }
        
        public PictureController(IPictureService pictureService)
        {
            PictureService = pictureService;
        }
        public async Task<IActionResult> ListPictures()
        {
            return View(await this.PictureService.GetPicture());
        }
        public async Task<IActionResult> InfoPicture(int id)
        {
            return View(await this.PictureService.GetPicture(id));
        }
        
        public async Task<IActionResult> AddPicture()
        {
            return View(await this.PictureService.GetPicture());
        }
        [HttpPost]
        public async Task<IActionResult> Put(Picture picture)
        {
            await this.PictureService.PutPicture(picture);
            return RedirectToAction("ListPictures");
        }
    }
}