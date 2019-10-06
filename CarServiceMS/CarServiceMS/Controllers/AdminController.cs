using System.Linq;
using System.Threading.Tasks;
using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using CarServiceMS.Models.BindingModels;
using CarServiceMS.Models.BindingModels.AdminServices;
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


        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
                               RoleManager<IdentityRole> roleManager, IAdminService adminService)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.adminService = adminService;
        }

        [HttpGet]
        public IActionResult RegisterAdmin(string username, string userId)
        {
            var model = new AdminBindingModel()
            {
                Username = username,
                UserId = userId
               
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(AdminBindingModel adminInputModel)
        {
            var adminUser = await this.context.Users.SingleOrDefaultAsync(userFromDb => userFromDb.UserName == this.User.Identity.Name);

            var validPassword = await userManager.CheckPasswordAsync(adminUser, adminInputModel.SecretPassword);

            var user = await userManager.FindByNameAsync(adminInputModel.Username);


            if (ModelState.IsValid && validPassword && user != null)
            {

                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }


                if (await userManager.IsInRoleAsync(user, "Banned"))
                {
                    await userManager.RemoveFromRoleAsync(user, "Banned");

                }
                else if (await userManager.IsInRoleAsync(user, "User"))
                {
                    await userManager.RemoveFromRoleAsync(user, "User");

                }

                await userManager.AddToRoleAsync(user, "Admin");
                await adminService.ChangeUserRole(user, "Admin");

                return RedirectToAction("ShowUsersDetails", "UsersAdmin", new { id = user.Id });
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

        [HttpGet]
        public IActionResult BanUser(string username, string userId)
        {
            var model = new AdminBindingModel()
            {
                Username = username,
                UserId = userId
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> BanUser(AdminBindingModel adminInputModel)
        {
            var adminUser = await this.context.Users.SingleOrDefaultAsync(userFromDb => userFromDb.UserName == this.User.Identity.Name);

            var validPassword = await userManager.CheckPasswordAsync(adminUser, adminInputModel.SecretPassword);

            var user = await userManager.FindByNameAsync(adminInputModel.Username);


            if (ModelState.IsValid && validPassword && user != null)
            {

                if (!await roleManager.RoleExistsAsync("Banned"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Banned"));
                }


                if (await userManager.IsInRoleAsync(user, "Admin"))
                {
                    await userManager.RemoveFromRoleAsync(user, "Admin");

                }
                else if(await userManager.IsInRoleAsync(user, "User"))
                {
                    await userManager.RemoveFromRoleAsync(user, "User");

                }

                await userManager.AddToRoleAsync(user, "Banned");
                await adminService.ChangeUserRole(user, "Banned");
                return RedirectToAction("ShowUsersDetails", "UsersAdmin", new { id = user.Id });
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

        [HttpGet]
        public IActionResult MakeUser(string username, string userId)
        {
            var model = new AdminBindingModel()
            {
                Username = username,
                UserId = userId
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> MakeUser(AdminBindingModel adminInputModel)
        {
            var adminUser =  this.context.Users.SingleOrDefault(userFromDb => userFromDb.UserName == this.User.Identity.Name);

            var validPassword = await userManager.CheckPasswordAsync(adminUser, adminInputModel.SecretPassword);

            var user = await userManager.FindByNameAsync(adminInputModel.Username);


            if (ModelState.IsValid && validPassword && user != null)
            {

                if (!await roleManager.RoleExistsAsync("User"))
                {
                    await roleManager.CreateAsync(new IdentityRole("User"));
                }


                if (await userManager.IsInRoleAsync(user, "Admin"))
                {
                    await userManager.RemoveFromRoleAsync(user, "Admin");

                }
                else if (await userManager.IsInRoleAsync(user, "Banned"))
                {
                    await userManager.RemoveFromRoleAsync(user, "Banned");

                }

                await userManager.AddToRoleAsync(user, "User");
                await adminService.ChangeUserRole(user, "User");

                return RedirectToAction("ShowUsersDetails", "UsersAdmin", new { id = user.Id });
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

        [HttpGet]
        public IActionResult AdminServices()
        {

            var totalUsersCount = this.adminService.GetAllUsers().Count();


            var adminsCount = this.adminService.GetAllAdmins().Count();
            var bannedCount = this.adminService.GetAllBannedUsers().Count();
            var ordinaryUseres = this.adminService.GetAllOrinaryUsers().Count();

            var usersData = new UsersDataBindingModel()
            {
                Count = totalUsersCount,
                AdminsCount = adminsCount,
                BannedCount = bannedCount,
                OrdinaryCount = ordinaryUseres
            };

            var carsCount = this.adminService.GetAllCars().Count();

            var carsData = new CarsDataBindingModel()
            {
                Count = carsCount,
                InPrcessCount = carsCount,
                ReadyCount = 0,
                WaitingCount = 0
            };


            var usersCarsProfits = new AdminServicesBindingModel()
            {
                UsersData = usersData,
                CarsData = carsData
            };

            return this.View(usersCarsProfits);
        }


    }
}