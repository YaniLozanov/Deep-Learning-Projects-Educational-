using Stopify.Services.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stopify.Services
{
    public interface IProductService
    {
        IQueryable<ProductTypeServiceModel> GetAllProductTypes();
        IQueryable<ProductServiceModel> GetAllProducts();

        ProductServiceModel GetProductById(string id);

        Task<bool> Create(ProductServiceModel productServiceModel);
        Task<bool> CreateProductType(ProductTypeServiceModel productTypeServiceModel);
    }
}
