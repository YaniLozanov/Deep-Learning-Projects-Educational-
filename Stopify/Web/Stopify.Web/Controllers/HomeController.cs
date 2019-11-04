using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stopify.Services;
using Stopify.Web.ViewModels.Home.Index;

namespace Stopify.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public HomeController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index([FromQuery]string criteria = null)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                var products = await this.productService.GetAllProducts()
                    .Select(product => this.mapper.Map<ProductHomeViewModel>(product))
                    .ToListAsync();

                this.ViewData["criteria"] = criteria;

                return this.View(products);
            }

            return View();
        }
    }
}
