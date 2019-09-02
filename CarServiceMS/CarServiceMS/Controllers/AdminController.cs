using System.Linq;
using System.Threading.Tasks;
using CarLibraryMS.Service;
using CarServiceMS.Data;
using CarServiceMS.Data.Interfaces;
using CarServiceMS.Data.Models;
using CarServiceMS.Models.BindingModels;
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
                    MemberSince = user.MemberSince
                });

            var viewUsers = new UsersListingModel()
            {
                Users = users
            };


            return this.View(viewUsers);
        }



    }
}