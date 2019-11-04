using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Stopify.Services;
using Stopify.Web.ViewModels;

namespace Stopify.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "Details")]
        public IActionResult Details(string id)
        {
            var productServiceModel = this.productService.GetProductById(id);

            var productDetailsViewModel = this.mapper.Map<ProductDetailsViewModel>(productServiceModel);

            return this.View(productDetailsViewModel);
        }
    }
}
