using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using FuelAccounting.Context.Contracts.Enums;
using FuelAccounting.Context.Contracts.Models;
using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.Models.Enums;

namespace FuelAccounting.Services.Automappers
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<FuelTypes, FuelTypesModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<UserTypes, UserTypesModel>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<Driver, DriverModel>(MemberList.Destination);

            CreateMap<FuelStation, FuelStationModel>(MemberList.Destination);

            CreateMap<Supplier, SupplierModel>(MemberList.Destination);

            CreateMap<Trailer, TrailerModel>(MemberList.Destination);

            CreateMap<Truck, TruckModel>(MemberList.Destination);

            CreateMap<User, UserModel>(MemberList.Destination);

            CreateMap<Fuel, FuelModel>(MemberList.Destination)
                .ForMember(x => x.Supplier, next => next.Ignore());

            CreateMap<FuelAccountingItem, FuelAccountingItemModel>(MemberList.Destination)
                .ForMember(x => x.Driver, next => next.Ignore())
                .ForMember(x => x.Truck, next => next.Ignore())
                .ForMember(x => x.Trailer, next => next.Ignore())
                .ForMember(x => x.Fuel, next => next.Ignore())
                .ForMember(x => x.FuelStation, next => next.Ignore());
        }
    }
}
