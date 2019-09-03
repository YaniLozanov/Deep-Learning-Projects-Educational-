using System.Linq;
using System.Threading.Tasks;
using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using CarServiceMS.Models.BindingModels;
using CarServiceMS.Models.BindingModels.AdminServices;
using CarServiceMS.Models.CarModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarServiceMS.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IAdminService adminService;
        private readonly ICarService carService;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager, IAdminService adminService,
                               ICarService carService)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.adminService = adminService;
            this.carService = carService;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(AdminBindingModel adminInputModel)
        {
            var adminUser = await this.context.Users.SingleOrDefaultAsync(user => user.UserName == this.User.Identity.Name);

            var validPassword = await userManager.CheckPasswordAsync(adminUser, adminInputModel.SecretPassword);

            if (ModelState.IsValid && validPassword)
            {
                var admin = await userManager.FindByNameAsync(adminInputModel.Username);

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                await userManager.AddToRoleAsync(admin, "Admin");

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return this.View();
            }
        }

        [Authorize(Roles = "Admin")]
        public  IActionResult ListUsers()
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
                }); 

            var viewUsers = new UsersListingModel()
            {
                Users = users
            };


            return this.View(viewUsers);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult ListUserCars(string id)
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

                var carsBinding = new CarListingModel()
                {
                    Cars = cars
                };

                return this.View(carsBinding);
            }
            else
            {
                return this.View();
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminServices()
        {

            var totalUsersCount = this.adminService.GetAllUsers().Count();


            var adminsCount = this.adminService.GetAllAdmins().Count();
            var bannedCount = 0;
            var ordinaryUseres = totalUsersCount - adminsCount - bannedCount;

            var usersData = new UsersDataBindingModel()
            {
                Count = totalUsersCount,
                AdminsCount = adminsCount,
                BannedCount = bannedCount,
                OrdinaryCount = ordinaryUseres
            };

            var usersCarsProfits = new AdminServicesBindingModel()
            {
                UsersData = usersData
            };

            return this.View(usersCarsProfits);
        }


    }
}