using AutoMapper;
using ERP.Dto;
using ERP.Models;

namespace ERP.Profiles
{
    public class GDRProfiles : Profile
    {
        public GDRProfiles()
        {
            CreateMap<CompanyDto, EntityCompany>();
            CreateMap<CustomerDto, EntityCustomer>();
            CreateMap<UserDto, EntityUser>();
            CreateMap<CustomerUserDto, EntityCustomerUser>();
            CreateMap<PackageDto, EntityPackage>();
            CreateMap<ServiceDto, EntityService>();
            CreateMap<EmployeeDto, EntityEmployee>();
            CreateMap<SupplierDto, EntitySupplier>();
            CreateMap<ProductDto, EntityProduct>();
        }
    }
}
