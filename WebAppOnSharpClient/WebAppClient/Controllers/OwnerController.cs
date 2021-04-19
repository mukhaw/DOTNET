using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppClient.Models;
using WebAppClient.Services.Contracts;

namespace WebAppClient.Controllers
{
    public class OwnerController : Controller
    {
        private IOwnerService OwnerService { get; }
        
        public OwnerController(IOwnerService ownerService)
        {
            OwnerService = ownerService;
        }
        public async Task<IActionResult> List()
        {
            return View(await this.OwnerService.GetOwner());
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View(await this.OwnerService.GetOwner());
        }
        [HttpPost]
        public async Task<IActionResult> Put(Owner owner)
        {
            await this.OwnerService.PutOwner(owner);
            return RedirectToAction("List");
        }
    }
}