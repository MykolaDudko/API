using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

namespace ClassLibrary.Profiles;

public class HandoverPointProfile : Profile
{
    public HandoverPointProfile()
    {
        CreateMap<HandoverPointModel, HandoverPointResponse>();
        CreateMap<HandoverPointResponse, HandoverPointModel>();
        CreateMap<HandoverPointModel, HandoverPointModel>();

        CreateMap<HandoverPointModel, CreateHandoverPointRequest>();
        CreateMap<CreateHandoverPointRequest, HandoverPointModel>();
        CreateMap<HandoverPointModel, UpdateHandoverPointRequest>();
        CreateMap<UpdateHandoverPointRequest, HandoverPointModel>();
    }
}
