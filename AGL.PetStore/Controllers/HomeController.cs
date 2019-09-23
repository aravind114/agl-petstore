using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AGL.PetStore.Models;
using AGL.PetStore.ViewModels;
using AGL.PetStore.Services;
using System;
using System.Threading.Tasks;

namespace AGL.PetStore.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IPetStoreService petStoreService)
        {
            PetStoreService = petStoreService;
        }

        public IPetStoreService PetStoreService { get; }

        public async Task<IActionResult> Index()
        {
            var petOwners = new List<PetOwnersModel>();
            var catsViewModel = new List<PetsViewModel>();
            try
            {
                petOwners = await PetStoreService.GetPetOwners();

                if (petOwners != null)
                {
                    //construct cats view model
                    catsViewModel = petOwners.Where(owner => owner.Pets != null)
                       .SelectMany(owner => owner.Pets, (owner, pet) => new PetsViewModel()
                       { Name = pet.Name, Type = pet.Type, OwnersGender = owner.Gender, OwnersName = owner.Name })
                       .Where(p => p.Type.ToLower() == "cat")
                       .OrderBy(p => p.Name).ToList();
                }
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                //LOG Exception
            }
            return View(catsViewModel);
        }
    }

}

   