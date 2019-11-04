using System.Linq;
using System.Threading.Tasks;
using Stopify.Data;
using Stopify.Data.Models;
using Stopify.Services.Models;
using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Stopify.Services
{
    public class ProductService : IProductService
    {
        private readonly StopifyDbContext context;
        private readonly IMapper mapper;

        public ProductService(StopifyDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        private ProductType GetProductTypeByName(string name)
        {
            return this.context.ProductTypes
                .SingleOrDefault(type => type.Name == name);
        }

        public IQueryable<ProductServiceModel> GetAllProducts()
        {
            return this.context.Products
                  .Select(x => mapper.Map<ProductServiceModel>(x));

        }
        public IQueryable<ProductTypeServiceModel> GetAllProductTypes()
        {
            return this.context.ProductTypes.
                Select(x => mapper.Map<ProductTypeServiceModel>(x));

        }

        public async Task<bool> Create(ProductServiceModel productServiceModel)
        {

            ProductType productTypeFromDb = GetProductTypeByName(productServiceModel.ProductType.Name);

            if (productTypeFromDb == null)
            {
                throw new ArgumentNullException(nameof(productTypeFromDb));
            }

            Product product = mapper.Map<Product>(productServiceModel);
            product.ProductType = productTypeFromDb;

            context.Products.Add(product);
            int result = await context.SaveChangesAsync();

            return result > 0;

        }
        public async Task<bool> CreateProductType(ProductTypeServiceModel productTypeServiceModel)
        {
            ProductType productType = mapper.Map<ProductType>(productTypeServiceModel);

            context.ProductTypes.Add(productType);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public ProductServiceModel GetProductById(string id)
        {
            Product productFromDb = this.context
                .Products
                .Include(x => x.ProductType)
                .FirstOrDefault(p => p.Id == id);
                

            ProductServiceModel productServiceModel = this.mapper.Map<ProductServiceModel>(productFromDb);

            return productServiceModel;
                
        }
    }
}
