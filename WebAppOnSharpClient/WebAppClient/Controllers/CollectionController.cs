using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class CollectionController : Controller
    {
        // GET
        private ICollectionService ColllectionService { get; }
        
        public CollectionController(ICollectionService CollectionService)
        {
            CollectionService = CollectionService;
        }
        public async Task<IActionResult> ListCollection()
        {
            return View(await this.CollectionService.GetCollection());
        }

      
        [HttpPost]
        public async Task<IActionResult> Put(Collection collection)
        {
            await this.CollectionService.PutCollection(Collection);
            return RedirectToAction("ListCollections");
        }

    }
}