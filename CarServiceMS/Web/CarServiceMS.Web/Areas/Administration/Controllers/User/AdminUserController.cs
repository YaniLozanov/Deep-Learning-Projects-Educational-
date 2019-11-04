using AutoMapper;
using CarServiceMS.Data.Models;
using CarServiceMS.Service.Models;
using CarServiceMS.Services.Interfaces.AdminInterfaces;
using CarServiceMS.Services.Interfaces.CarInterfaces;
using CarServiceMS.Services.Interfaces.UserInterfaces;
using CarServiceMS.Web.InputModels.AdminInputModels.AdminUserInputModels;
using CarServiceMS.Web.ViewModels.AdminViewModels.AdminUserViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceMS.Web.Areas.Administration.Controllers.User
{
    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    public class AdminUserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;
        private readonly IAdminServices adminServices;
        private readonly IUserServices userServices;
        private readonly ICarServices carServices;



        public AdminUserController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
                                   IAdminServices adminServices, IUserServices userServices,
                                   ICarServices carServices, IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.adminServices = adminServices;
            this.userServices = userServices;
            this.carServices = carServices;
        }

        [HttpGet]
        public IActionResult ListAllUsers()
        {
            var users = this.userServices
                .GetAllUsers()
                .Select(user => this.mapper.Map<UserListingViewModel>(user));

            var viewUsers = new UserListWithViewModels()
            {
                Users = users
            };


            return this.View(viewUsers);
        }
        [HttpGet]
        public IActionResult ListUserCars(string id, string username)
        {
            var carsFromDb = this.carServices.GetAllCarsForUserWithId(id);

            if (carsFromDb != null)
            {
                var cars = carsFromDb.Select(car => this.mapper.Map<UserCarsListingViewModel>(car));

                var carsBinding = new UserCarsListWithViewModels()
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
        public async Task<IActionResult> CreateUsersCar(UserCarCreateInputModel carModel, string username)
        {
            if (ModelState.IsValid)
            {
                var user = this.userServices.GetUserByName(username);
                var car = this.mapper.Map<CarServiceModel>(carModel);
                car.Owner = user;

                await this.carServices.AddCarAsync(car);

                return this.RedirectToAction($"ListUserCars", "AdminUser", new { id = user.Id, username = user.UserName });
            }
            else
            {
                ModelState.AddModelError("Number", "Invalid Number");
                return this.View(carModel);


            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUsersCar(UserCarsListWithViewModels model)
        {
            var carId = model.Id;
            var password = model.Password;
            var user = this.userServices.GetUserByCarId(carId);
            var admin = await this.userManager.GetUserAsync(this.User);

            var isPasswordValid = false;

            if (password != null)
            {
                isPasswordValid = await userManager.CheckPasswordAsync(admin, password);

            }

            if (this.ModelState.IsValid && isPasswordValid)
            {
              await this.carServices.DeleteCarAsync(model.Id);


                return this.RedirectToAction($"ListUserCars", "AdminUser", new { id = user.Id, username = user.UserName });



            }
            else
            {
                if (isPasswordValid == false)
                {
                    ModelState.AddModelError(string.Empty, "Ivalid Password!");
                    return this.RedirectToAction($"ListUserCars", "AdminUser", new { id = user.Id, username = user.UserName });

                }
                else
                {
                    return this.RedirectToAction($"ListUserCars", "AdminUser", new { id = user.Id, username = user.UserName });
                }
            }
        }
        [HttpGet]
        public IActionResult EditUsersCar(int id)
        {
            var car = carServices.GetCarById(id);

            var editCarModel = this.mapper.Map<UserCarEditInputModel>(car);

            return this.View(editCarModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditUsersCar(UserCarEditInputModel carModel)
        {

            if (this.ModelState.IsValid)
            {
                var car = this.carServices.GetCarById(carModel.Id);
                var user = this.userServices.GetUserByCarId(carModel.Id);

                car.Brand = carModel.Brand;
                car.Model = carModel.Model;
                car.YearFrom = carModel.YearFrom;

                if (car.Number != carModel.Number)
                {
                    if (!this.carServices.IsThereSuchCarWithNumber(carModel.Number))
                    {
                        car.Number = carModel.Number;
                    }
                    else
                    {

                        ModelState.AddModelError("Number", "Invalid Number");
                        return this.View(carModel);
                    }
                }

                await this.carServices.EditCarDataAsync(car);

                return RedirectToAction("ListUserCars", "AdminUser", new { id = user.Id, username = user.UserName });
            }
            else
            {

                ModelState.AddModelError("Number", "Invalid Number");
                return this.View(carModel);
            }
        }
        [HttpGet]
        public IActionResult ShowUserDetails(string id)
        {
            var user = this.userServices.GetUserById(id);

            var usersDetailModel = this.mapper.Map<UserDetailsViewModel>(user);
            return View(usersDetailModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditPersonalityDesctription(string id, UserDetailsViewModel model)
        {
            var description = model.PersonalityDesctription;

            await this.adminServices.EditPersonalityDesctriptionAsync(id, description);

            return RedirectToAction("ShowUserDetails", "AdminUser", new { id = id });
        }
        [HttpGet]
        public IActionResult ChangeUserRole(string username, string userId, string currentRole)
        {
            var model = new ChangeUserRoleInputModel()
            {
                Username = username,
                UserId = userId,
                RoleName = currentRole
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserRole(ChangeUserRoleInputModel changeUserRoleInputModel)
        {
            // Validate The admin
            var admin = this.userServices.GetUserByName(changeUserRoleInputModel.Username);
            var validPassword = await userManager
                .CheckPasswordAsync(this.mapper.Map<ApplicationUser>(admin),
                                    changeUserRoleInputModel.SecretPassword);

            var user = await userManager.FindByNameAsync(changeUserRoleInputModel.Username);


            if (ModelState.IsValid && validPassword && user != null)
            {
                var userRoles = await this.userManager.GetRolesAsync(user);
                await userManager.RemoveFromRoleAsync(user, userRoles[0]);


                if (!await this.roleManager.RoleExistsAsync(changeUserRoleInputModel.RoleName))
                {
                    await this.roleManager.CreateAsync(new IdentityRole(changeUserRoleInputModel.RoleName));
                }

                await userManager.AddToRoleAsync(user, changeUserRoleInputModel.RoleName);
                await adminServices.ChangeUserRoleAsync(this.mapper.Map<ApplicationUserServiceModel>(user), changeUserRoleInputModel.RoleName); ;

                return RedirectToAction("ShowUserDetails", "AdminUser", new { id = user.Id });
            }
            else
            {
                if (user == null)
                {
                    ModelState.AddModelError("Username", "There is no such user!");

                }
                else if (validPassword == false)
                {
                    ModelState.AddModelError("Password", "Invalid Passowrd!");

                }

                return this.View();
            }
        }

    }
}
