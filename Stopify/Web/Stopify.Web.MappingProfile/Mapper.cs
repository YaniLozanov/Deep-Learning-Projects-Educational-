using AutoMapper;
using Stopify.Services.Models;
using Stopify.Web.BindingModels;

namespace Stopify.Web.MappingProfile
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<ProductCreateInputModel, ProductServiceModel>();
        }
    }
}
