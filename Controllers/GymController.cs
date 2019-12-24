using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemo.GymServices;
using DapperDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.Controllers
{
    public class GymController : Controller
    {
        private readonly IGymService _gymService;

        public GymController(IGymService gymService)
        {
            _gymService = gymService;
        }

        public IActionResult AllLocations()
        {
            var result = _gymService.GetAllLocations();

            return View(result);
        }

        public IActionResult LocationInfo(int id)
        {
            var result = _gymService.ViewLocation(id);

            return View(result);
        }

        public IActionResult AddLocation()
        {
            return View();
        }

        public IActionResult AddLocationResults(AddLocationViewModel model)
        {
            var locationsViewModel = _gymService.AddNewLocation(model);
            return View("AdditionResults", locationsViewModel);
        }

        public IActionResult EditGymInfo(int id)
        {
            var result = _gymService.ViewLocation(id);

            return View(result);
        }

        public IActionResult EditLocationResults(LocationViewModel model)
        {
            var result = _gymService.EditGymLocationInfo(model);
              
            return View(result);
        }

        public IActionResult RemoveGymLocation(int id)
        {
            var result = _gymService.DeleteGymLocation(id);

            return View(result);
        }
        
    }
    
}