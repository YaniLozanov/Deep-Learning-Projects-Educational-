using AutoMapper;
using CarServiceMS.Data.Models;
using CarServiceMS.Data.Models.CarServicesModels;
using CarServiceMS.Data.Models.CarServicesModels.MaintenanceModels;
using CarServiceMS.Service.Models;
using CarServiceMS.Web.InputModels;
using CarServiceMS.Web.InputModels.AdminInputModels.AdminCarInputModels;
using CarServiceMS.Web.InputModels.AdminInputModels.AdminUserInputModels;
using CarServiceMS.Web.InputModels.CarInputModels;
using CarServiceMS.Web.ViewModels.AdminViewModels.AdminCarViewModels;
using CarServiceMS.Web.ViewModels.AdminViewModels.AdminUserViewModels;
using CarServiceMS.Web.ViewModels.CarServicesViewModels;
using CarServiceMS.Web.ViewModels.CarServicesViewModels.MaintananceViewModels;
using CarServiceMS.Web.ViewModels.CarServicesViewModels.RepairViewModels;
using CarServiceMS.Web.ViewModels.CarViewModels;
using System.Collections;
using System.Linq;

namespace CarServiceMS.Service.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // User Mappings
            CreateMap<ApplicationUser, ApplicationUserServiceModel>()
                .ReverseMap();

            CreateMap<UserListingViewModel, ApplicationUserServiceModel>();
            CreateMap<ApplicationUserServiceModel, UserListingViewModel>();

            CreateMap<UserDetailsViewModel, ApplicationUserServiceModel>();
            CreateMap<ApplicationUserServiceModel, UserDetailsViewModel>()
                .ForMember(dest => dest.CarsCount, opt => opt.MapFrom(src => src.Cars.ToList().Count));


            // Car Mappings
            CreateMap<Car, CarServiceModel>();
            CreateMap<CarServiceModel, Car>();

            CreateMap<CarCreateInputModel, CarServiceModel>();
            CreateMap<CarServiceModel, CarCreateInputModel>();

            CreateMap<CarServiceModel, CarListingViewModel>(); 
            CreateMap<CarListingViewModel, CarServiceModel>();

            CreateMap<UserCarCreateInputModel, CarServiceModel>();
            CreateMap<CarServiceModel, UserCarCreateInputModel>();

            CreateMap<UserCarEditInputModel, CarServiceModel>();
            CreateMap<CarServiceModel, UserCarEditInputModel>();

            CreateMap<UserCarsListingViewModel, CarServiceModel>();
            CreateMap<CarServiceModel, UserCarsListingViewModel>();

            CreateMap<CarServiceModel, CarEditInputModel>();
            CreateMap<CarEditInputModel, CarServiceModel>();

            CreateMap<AdminCarListingViewModel, CarServiceModel>();
            CreateMap<CarServiceModel, AdminCarListingViewModel>();

            CreateMap<AdminCarEditInputModel, CarServiceModel>();
            CreateMap<CarServiceModel, AdminCarEditInputModel>();
            CreateMap<CarServiceModel, CarViewModel>();



            // Car Services Mappings

            // Repairs
            CreateMap<Repair, RepairServiceModel>()
                .ReverseMap();
            CreateMap<RepairPart, RepairPartServiceModel>()
                .ReverseMap();
            CreateMap<ReportedDefect, ReportedDefectServiceModel>()
                .ReverseMap();   
            CreateMap<CompletedAction, CompletedActionServiceModel>()
                .ReverseMap();
            CreateMap<CarServiceAbstractModel, CompletedActionServiceModel>()
                .ReverseMap();

            CreateMap<RepairServiceModel, RepairDetailsViewModel>();
            CreateMap<RepairServiceModel, RepairListingViewModel>();
            CreateMap<RepairPartServiceModel, RepairPartViewModel>();
            CreateMap<ReportedDefectServiceModel, ReportedDefectViewModel>();
            CreateMap<CompletedActionServiceModel, CompletedActionViewModel>();

            // Maintanances
            CreateMap<Maintenance, MaintenanceServiceModel>()
                .ReverseMap();
            CreateMap<MaintenancePart, MaintenancePartServiceModel>()
                .ReverseMap();

            CreateMap<MaintenanceServiceModel, MaintananceListingViewModel>();
            CreateMap<MaintenanceServiceModel, MaintananceDetailsViewModel>();
            CreateMap<MaintenancePartServiceModel, MaintanancePartViewModel>();

        }
    }
}
