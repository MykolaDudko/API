using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;
using Library.Models;

namespace ClassLibrary.Profiles;

public class CarrierProfile : Profile
{
    public CarrierProfile()
    {
        CreateMap<CarrierModel, CarrierResponse>();
        CreateMap<CarrierResponse, CarrierModel>();
        CreateMap<CarrierModel, CarrierModel>();

        CreateMap<CarrierModel, CreateCarrierRequest>();
        CreateMap<CreateCarrierRequest, CarrierModel>();
        CreateMap<UpdateCarrierRequest, CarrierModel>();
        CreateMap<CarrierModel, UpdateCarrierRequest>();
    }
}
