using AutoMapper;
using CarServiceMS.Service.AutoMapper;

namespace CarServiceMS.Tests.Factories
{
    public class AutoMapperFactory
    {
        public Mapper CreateMapper()
        {

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            return new Mapper(mappingConfig);
        }
    }
}
