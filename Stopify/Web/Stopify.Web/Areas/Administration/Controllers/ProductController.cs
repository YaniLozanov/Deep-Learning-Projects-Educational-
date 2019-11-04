using Microsoft.AspNetCore.Mvc;
using Stopify.Services;
using Stopify.Services.Models;
using Stopify.Web.InputModels;
using Stopify.Web.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Stopify.Web.Areas.Administration.Controllers
{

    public class ProductController : AdminController
    {
        private readonly IProductService productService;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, ICloudinaryService cloudinaryService,
                                 IMapper mapper)
        {

            this.productService = productService;
            this.cloudinaryService = cloudinaryService;
            this.mapper = mapper;
        }

        [HttpGet("/Administration/Product/Type/Create")]
        public async Task<IActionResult> CreateType()
        {
            return this.View("Type/Create");
        }

        [HttpPost("/Administration/Product/Type/Create")]
        public async Task<IActionResult> CreateType(ProductTypeCreateInputModel productTypeCreateInputModel)
        {
            ProductTypeServiceModel productTypeServiceModel = mapper.Map<ProductTypeServiceModel>(productTypeCreateInputModel);

            await this.productService.CreateProductType(productTypeServiceModel);

            return this.Redirect("/");
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            var allProductTypes = await this.productService.GetAllProductTypes().ToListAsync();

            this.ViewData["types"] = allProductTypes.Select(productType => mapper.Map<ProductCreateProductTypeViewModel>(productType))
               .ToList();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateInputModel productCreateInputModel)
        {


            if (!this.ModelState.IsValid)
            {
                var allProductTypes = await this.productService.GetAllProductTypes().ToListAsync();

                this.ViewData["types"] = allProductTypes.Select(productType => mapper.Map<ProductCreateProductTypeViewModel>(productType))
                .ToList();



                return this.View();
            }

            string pictureUrl = await this.cloudinaryService.UploadPictureAsync(
                productCreateInputModel.Picture,
                productCreateInputModel.Name);

            ProductServiceModel productServiceModel = mapper.Map<ProductServiceModel>(productCreateInputModel);


            productServiceModel.Picture = pictureUrl;

            await this.productService.Create(productServiceModel);

            return this.Redirect("/");



        }
    }
}