using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using CarServiceMS.Models.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CarServiceMS.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly UserManager<ApplicationUser> manager;

        public CarController(ICarService carService, UserManager<ApplicationUser> manager)
        {
            this.carService = carService;
            this.manager = manager;
        }

        [Authorize]
        public IActionResult Create ()
        {
            return this.View();
        }
    
        [HttpPost]   
        public IActionResult Create(CarBindingModel carModel)
        {
            var car = new Car
            {
                Brand = carModel.Brand,
                Model = carModel.Model,
                YearFrom = carModel.YearFrom,
                RegistredOn = DateTime.Now,
                Number = carModel.Number,
                Owner = this.carService.GetUserById(manager.GetUserId(User))
            };

            if (this.ModelState.IsValid)
            {
                this.carService.AddCar(car);

                return RedirectToAction("Index", "Home");
            }
            else
            {

                return this.View();
            }
        }

    }
}
