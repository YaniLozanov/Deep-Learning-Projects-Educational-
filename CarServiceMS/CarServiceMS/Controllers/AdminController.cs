using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceMS.Data;
using CarServiceMS.Data.Models;
using CarServiceMS.Models.BindingModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CarServiceMS.Controllers
{
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

        public IActionResult RegisterAdmin()
        {
            

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(AdminBindingModel adminInputModel)
        {
            var admin = await userManager.FindByNameAsync(adminInputModel.Username);

            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            await userManager.AddToRoleAsync(admin, "Admin");

            return RedirectToAction("Index", "Home");
        }



    }
}