using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

namespace ClassLibrary.Profiles;

public class ConsignorProfile : Profile
{
    public ConsignorProfile()
    {
        CreateMap<ConsignorModel, ConsignorResponse>();
        CreateMap<ConsignorResponse, ConsignorModel>();
        CreateMap<ConsignorModel, ConsignorModel>();

        CreateMap<ConsignorModel, CreateConsignorRequest>();
        CreateMap<CreateConsignorRequest, ConsignorModel>();
        CreateMap<ConsignorModel, UpdateConsignorRequest>();
        CreateMap<UpdateConsignorRequest, ConsignorModel>();
    }
}
