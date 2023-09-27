using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

namespace ClassLibrary.Profiles;

public class TransportServiceProfile : Profile
{
    public TransportServiceProfile()
    {
        CreateMap<TransportServiceModel, TransportServiceResponse>();
        CreateMap<TransportServiceResponse, TransportServiceModel>();
        CreateMap<TransportServiceModel, TransportServiceModel>();


        CreateMap<TransportServiceModel, CreateTransportServiceRequest>();
        CreateMap<CreateTransportServiceRequest, TransportServiceModel>();
        CreateMap<TransportServiceModel, UpdateTransportServiceRequest>();
        CreateMap<UpdateTransportServiceRequest, TransportServiceModel>();
    }
}
