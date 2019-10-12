using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Panda.App.Models.Package;
using Panda.App.Models.Recipients;
using Panda.Domain;
using Panda.Services;
using System;
using System.Globalization;
using System.Linq;

namespace Panda.App.Controllers
{
    [Authorize(Roles = "Admin")]
    public class PackagesController : Controller
    {
        private readonly IUsersService usersService;
        private readonly IPackagesService packagesService;
        private readonly IReceiptsService receiptsService;       

        public PackagesController(IUsersService usersService, IPackagesService packagesService, IReceiptsService receiptsService)
        {
            this.usersService = usersService;
            this.packagesService = packagesService;
            this.receiptsService = receiptsService;            
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Recipients = usersService.GetAllUsers();


            return this.View(new PackageCreateBindingModel());
        }

        [HttpPost]
        public IActionResult Create(PackageCreateBindingModel bindingModel)
        {
            if(!this.ModelState.IsValid)
            {
                return this.View(bindingModel ?? new PackageCreateBindingModel());
            }

            Package package = new Package
            {
                Description = bindingModel.Description,
                Recipient = this.usersService.GetUser(bindingModel.Recipient),
                ShippingAddress = bindingModel.ShippingAddress,
                Weight = bindingModel.Weight,
                Status = this.packagesService.GetPackageStatus("Pending")
            };

            this.packagesService.AddPackage(package);

            return this.Redirect("/Packages/Pending");
        }

        [HttpGet("/Packages/Details/{id}")]
        [Authorize]
        public IActionResult Details(string id)
        {
            Package package = this.packagesService.GetPackage(id);

            PackageDetailsViewModel viewModel = new PackageDetailsViewModel
            {
                Description = package.Description,
                Recipient = package.Recipient.UserName,
                ShippingAddress = package.ShippingAddress,
                Weight = package.Weight,
                Status = package.Status.Name
            };

            if(package.Status.Name == "Pending")
            {
                viewModel.EstimatedDeliveryDate = "N/A";
            }
            else if(package.Status.Name == "Shipped")
            {
                viewModel.EstimatedDeliveryDate = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            else
            {
                viewModel.EstimatedDeliveryDate = "Delivered";
            }

            return this.View(viewModel);
        }

        [HttpGet("/Packages/Ship/{id}")]
        public IActionResult Ship(string id)
        {
            Package package = this.packagesService.GetPackage(id);
            package.Status = this.packagesService.GetPackageStatus("Shipped");
            package.EstimatedDeliveryDate = DateTime.Now.AddDays(new Random().Next(20, 40));
            this.packagesService.UpdatePackage(package);

            return this.Redirect("/Packages/Shipped");
        }

        [HttpGet("/Packages/Deliver/{id}")]
        public IActionResult Deliver(string id)
        {
            Package package = this.packagesService.GetPackage(id);
            package.Status = this.packagesService.GetPackageStatus("Delivered");
            package.EstimatedDeliveryDate = DateTime.UtcNow;
            this.packagesService.UpdatePackage(package);

            return this.Redirect("/Packages/Delivered");
        }

        [HttpGet("/Packages/Acquire/{id}")]
        [Authorize]
        public IActionResult Acquire(string id)
        {
            Package package = this.packagesService.GetPackage(id);
            package.Status = this.packagesService.GetPackageStatus("Acquired");
            this.packagesService.UpdatePackage(package);

            Receipt receipt = new Receipt
            {
                Fee = (decimal)(2.67 * package.Weight),
                IssuedOn = DateTime.Now,
                Package = package,
                Recipient = this.usersService.GetUser(this.User.Identity.Name)
            };

            this.receiptsService.AddReceipt(receipt);

            return this.Redirect("/Home/Index");
        }

        [HttpGet]
        public IActionResult Pending()
        {

            var packagesPending = this.packagesService.GetPackagesWithRecipientAndStatus()
               .Where(package => package.Status.Name == "Pending")
               .Select(package => new PackagePendingViewModel()
               {
                   Id = package.Id,
                   Description = package.Description,
                   Weight = package.Weight,
                   ShippingAddress = package.ShippingAddress,
                   Recipient = package.Recipient.UserName
               })
               .ToList();

            var packagesListingModel = new PackagePendingListnigViewModel()
            {
                Packages = packagesPending
            };


            return this.View(packagesListingModel);
 
        }

        [HttpGet]
        public IActionResult Shipped()
        {
            var shippedPackages = this.packagesService.GetPackagesWithRecipientAndStatus()
                .Where(package => package.Status.Name == "Shipped")
                .ToList();

            var packages = shippedPackages.Select(package => new PackageShippedViewModel()
            {

                Id = package.Id,
                Description = package.Description,
                Weight = package.Weight,
                EstimatedDeliveryDate = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                Recipient = package.Recipient.UserName
            })
            .ToList();

            var packagesListingModel = new PackageShippedListingViewModel()
            {
                Packages = packages
            };

            return this.View(packagesListingModel);


          //  return this.View(this.packagesService.GetPackagesWithRecipientAndStatus()
          //      .Where(package => package.Status.Name == "Shipped")
          //      .ToList().Select(package =>
          //      {
          //          return new PackageShippedViewModel
          //          {
          //              Id = package.Id,
          //              Description = package.Description,
          //              Weight = package.Weight,
          //              EstimatedDeliveryDate = package.EstimatedDeliveryDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
          //              Recipient = package.Recipient.UserName
          //          };
          //      }).ToList());
        }

        [HttpGet]
        public IActionResult Delivered()
        {
            var packagesDelivered = this.packagesService.GetPackagesWithRecipientAndStatus()
                .Where(package => package.Status.Name == "Delivered" || package.Status.Name == "Acquired")
                .Select(package => new PackageDeliveredViewModel()
                {
                    Id = package.Id,
                    Description = package.Description,
                    Weight = package.Weight,
                    ShippingAddress = package.ShippingAddress,
                    Recipient = package.Recipient.UserName
                    
                })
                .ToList();

            var packagesDeliveredListingModel = new PackageDeliveredListingViewModel()
            {
                Packages = packagesDelivered
            };

            return this.View(packagesDeliveredListingModel);

        }
    }
}