using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using CarServiceMS.Models.BindingModels;
using CarServiceMS.Models.BindingModels.AdminServices;
using CarServiceMS.Models.BindingModels.AdminServices.Users;
using CarServiceMS.Models.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Controllers.AdminServicesControllers
{
    [Authorize(Roles = "Admin")]
    public class UsersAdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAdminService adminService;
        private readonly ICarService carService;

        public UsersAdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager, IAdminService adminService,
                               ICarService carService)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.adminService = adminService;
            this.carService = carService;
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = this.adminService
                .GetAllUsers()
                .Select(user => new UserBindingModel()
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    MemberSince = user.MemberSince,
                    Cars = user.Cars,
                    Role = user.Role
                });

            var viewUsers = new UsersListingModel()
            {
                Users = users
            };


            return this.View(viewUsers);
        }

        [HttpGet]
        public IActionResult ListUserCars(string id, string username)
        {
            var carsFromDb = this.carService.GetAllCars(id);

            if (carsFromDb != null)
            {
                var cars = carsFromDb.Select(car => new CarBindingModel()
                {
                    Id = car.Id,
                    Brand = car.Brand,
                    Model = car.Model,
                    Number = car.Number,
                    YearFrom = car.YearFrom,

                });

                var carsBinding = new UsersCarsListingModel()
                {
                    Cars = cars,
                    Username = username,
                    UserId = id
                };

                return this.View(carsBinding);
            }
            else
            {
                return this.View();
            }
        }

        [HttpGet]
        public IActionResult CreateUsersCar(string username)
        {

            ViewBag.Id = username;
            return this.View();
        }
        [HttpPost]
        public IActionResult CreateUsersCar(CarBindingModel carModel, string username)
        {
            if (ModelState.IsValid)
            {
                var user = this.carService.GetUserByName(username);

                var car = new Car()
                {
                    Brand = carModel.Brand,
                    Model = carModel.Model,
                    YearFrom = carModel.YearFrom,
                    Number = carModel.Number,
                    RegistredOn = carModel.RegistredOn,
                    Owner = user
                };

                this.carService.AddCar(car);


                return this.RedirectToAction($"ListUserCars", "UsersAdmin", new { id = user.Id, username = user.UserName });

            }
            else
            {
                ModelState.AddModelError("Number", "Invalid Number");
                return this.View(carModel);


            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUsersCar(UsersCarsListingModel model)
        {
            var carId = model.Id;
            var password = model.Password;
            var user = this.carService.GetUserByCarId(carId);
            var admin = await this.userManager.GetUserAsync(this.User);

            var isPasswordValid = false;

            if (password != null)
            {
                isPasswordValid = await userManager.CheckPasswordAsync(admin, password);

            }

            if (this.ModelState.IsValid && isPasswordValid)
            {
                this.carService.RemoveCar(model.Id);


                return this.RedirectToAction($"ListUserCars", "UsersAdmin", new { id = user.Id, username = user.UserName });



            }
            else
            {
                if (isPasswordValid == false)
                {
                    ModelState.AddModelError(string.Empty, "Ivalid Password!");
                    return this.RedirectToAction($"ListUserCars", "UsersAdmin", new { id = user.Id, username = user.UserName });

                }
                else
                {
                    return this.RedirectToAction($"ListUserCars", "UsersAdmin", new { id = user.Id, username = user.UserName });
                }
            }
        }

        [HttpGet]
        public IActionResult EditUsersCar(int id)
        {
            var car = carService.GetCarById(id);

            var editCarModel = new EditCarBindingModel()
            {
                Id = car.Id,
                Model = car.Model,
                Brand = car.Brand,
                YearFrom = car.YearFrom,
                Number = car.Number,

            };

            return this.View(editCarModel);
        }

        [HttpPost]
        public IActionResult EditUsersCar(EditCarBindingModel carModel)
        {
            

            if (this.ModelState.IsValid)
            {
                var car = this.carService.GetCarById(carModel.Id);
                var user = carService.GetUserByCarId(carModel.Id);

                car.Brand = carModel.Brand;
                car.Model = carModel.Model;
                car.YearFrom = carModel.YearFrom;

                if (car.Number != carModel.Number)
                {
                    if (!this.carService.IsThereSuchCar(carModel.Number))
                    {
                        car.Number = carModel.Number;
                    }
                    else
                    {

                        ModelState.AddModelError("Number", "Invalid Number");
                        return this.View(carModel);
                    }
                }

                this.carService.EditCarData(car);

                return RedirectToAction("ListUserCars", "UsersAdmin", new { id = user.Id, username = user.UserName});
            }
            else
            {

                ModelState.AddModelError("Number", "Invalid Number");
                return this.View(carModel);
            }
        }

        [HttpGet]
        public IActionResult ShowUsersDetails(string id)
        {
            var user = adminService.GetUserById(id);

            var usersDetailModel = new UsersDetailsBindingModel()
            {
                Id = user.Id,
                Username = user.UserName,
                Email = user.Email,
                MemberSince = user.MemberSince,
                PersonalityDesctription = user.PersonalityDesctription,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role
            };
            


            return View(usersDetailModel);
        }

        [HttpPost]
        public IActionResult EditPersonalityDesctription(string id, UsersDetailsBindingModel model)
        {
            var description = model.PersonalityDesctription;

            adminService.EditPersonalityDesctription(id, description);

            return RedirectToAction("ShowUsersDetails", "UsersAdmin", new { id = id});
        }



    }
}
