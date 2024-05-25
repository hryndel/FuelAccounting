using AutoMapper;
using AutoMapper.Extensions.EnumMapping;
using FuelAccounting.API.Models;
using FuelAccounting.API.Models.Enums;
using FuelAccounting.API.ModelsRequest.Driver;
using FuelAccounting.API.ModelsRequest.Fuel;
using FuelAccounting.API.ModelsRequest.FuelAccountingItem;
using FuelAccounting.API.ModelsRequest.FuelStation;
using FuelAccounting.API.ModelsRequest.Supplier;
using FuelAccounting.API.ModelsRequest.Trailer;
using FuelAccounting.API.ModelsRequest.Truck;
using FuelAccounting.API.ModelsRequest.User;
using FuelAccounting.Services.Contracts.Models;
using FuelAccounting.Services.Contracts.Models.Enums;
using FuelAccounting.Services.Contracts.RequestModels;

namespace FuelAccounting.API.Infrastructures
{
    /// <summary>
    /// Профиль маппера API
    /// </summary>
    public class ApiAutoMapperProfile : Profile
    {
        /// <summary>
        /// Инициализирует новый экземпляр <see cref="ApiAutoMapperProfile"/>
        /// </summary>
        public ApiAutoMapperProfile()
        {
            CreateMap<FuelTypesModel, FuelTypesResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<UserTypesModel, UserTypesResponse>()
                .ConvertUsingEnumMapping(opt => opt.MapByName())
                .ReverseMap();

            CreateMap<DriverModel, DriverResponse>(MemberList.Destination);
            CreateMap<CreateDriverRequest, DriverRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<DriverRequest, DriverRequestModel>(MemberList.Destination);

            CreateMap<TruckModel, TruckResponse>(MemberList.Destination);
            CreateMap<CreateTruckRequest, TruckRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<TruckRequest, TruckRequestModel>(MemberList.Destination);

            CreateMap<TrailerModel, TrailerResponse>(MemberList.Destination);
            CreateMap<CreateTrailerRequest, TrailerRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<TrailerRequest, TrailerRequestModel>(MemberList.Destination);

            CreateMap<SupplierModel, SupplierResponse>(MemberList.Destination);
            CreateMap<CreateSupplierRequest, SupplierRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<SupplierRequest, SupplierRequestModel>(MemberList.Destination);

            CreateMap<FuelModel, FuelResponse>(MemberList.Destination);
            CreateMap<CreateFuelRequest, FuelRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<FuelRequest, FuelRequestModel>(MemberList.Destination);

            CreateMap<FuelStationModel, FuelStationResponse>(MemberList.Destination);
            CreateMap<CreateFuelStationRequest, FuelStationRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<FuelStationRequest, FuelStationRequestModel>(MemberList.Destination);

            CreateMap<UserModel, UserResponse>(MemberList.Destination);
            CreateMap<CreateUserRequest, UserRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<UserRequest, UserRequestModel>(MemberList.Destination);

            CreateMap<FuelAccountingItemModel, FuelAccountingItemResponse>(MemberList.Destination);
            CreateMap<CreateFuelAccountingItemRequest, FuelAccountingItemRequestModel>(MemberList.Destination)
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<FuelAccountingItemRequest, FuelAccountingItemRequestModel>(MemberList.Destination);
        }
    }
}
