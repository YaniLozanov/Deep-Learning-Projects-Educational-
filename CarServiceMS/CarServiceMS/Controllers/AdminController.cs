using System.Threading.Tasks;
using CarServiceMS.Data;
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

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
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



    }
}