using AutoMapper;
using Stopify.Data.Models;
using Stopify.Services.Models;
using Stopify.Web.InputModels;
using Stopify.Web.ViewModels;
using Stopify.Web.ViewModels.Home.Index;

namespace Stopify.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Product Models Mapping.
            CreateMap<Product, ProductServiceModel>()
                .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => new ProductTypeServiceModel() { Name = src.ProductType.Name }));
            CreateMap<ProductServiceModel, Product>();
            CreateMap<ProductServiceModel, ProductCreateInputModel>()
                 .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => new ProductTypeServiceModel() { Name = src.ProductType.Name }));
            CreateMap<ProductCreateInputModel, ProductServiceModel>()
                 .ForMember(dest => dest.ProductType, opt => opt.MapFrom(src => new ProductTypeServiceModel() { Name = src.ProductType }));
            CreateMap<ProductDetailsViewModel, ProductServiceModel>();
            CreateMap<ProductServiceModel, ProductDetailsViewModel>();
            CreateMap<ProductServiceModel, ProductHomeViewModel>();
            CreateMap<ProductHomeViewModel, ProductServiceModel>();





            // ProductType Models Mapping.
            CreateMap<ProductType, ProductTypeServiceModel>();
            CreateMap<ProductTypeServiceModel, ProductType>();
            CreateMap<ProductCreateProductTypeViewModel, ProductTypeServiceModel>();
            CreateMap<ProductTypeServiceModel, ProductCreateProductTypeViewModel>();
            CreateMap<ProductTypeServiceModel, ProductTypeCreateInputModel>();
            CreateMap<ProductTypeCreateInputModel, ProductTypeServiceModel>();






        }
    }
}
