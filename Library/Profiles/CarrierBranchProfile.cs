using AutoMapper;
using ClassLibrary.DTOs;
using ClassLibrary.Models;

namespace ClassLibrary.Profiles;

public class CarrierBranchProfile : Profile
{
    public CarrierBranchProfile()
    {
        CreateMap<CarrierBranchCategoryModel, CarrierBranchCategoryResponse>();
        CreateMap<CarrierBranchCategoryResponse, CarrierBranchCategoryModel>();
        CreateMap<CarrierBranchCategoryModel, CreateCarrierBranchCategoryRequest>();
        CreateMap<CarrierBranchCategoryModel, UpdateCarrierBranchCategoryRequest>();
        CreateMap<CreateCarrierBranchCategoryRequest, CarrierBranchCategoryModel>();
        CreateMap<UpdateCarrierBranchCategoryRequest, CarrierBranchCategoryModel>();
        CreateMap<CarrierBranchCategoryModel, CarrierBranchCategoryModel>();
    }
}
