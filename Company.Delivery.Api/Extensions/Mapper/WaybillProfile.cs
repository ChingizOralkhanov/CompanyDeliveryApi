using AutoMapper;
using Company.Delivery.Api.Controllers.Waybills.Request;
using Company.Delivery.Api.Controllers.Waybills.Response;
using Company.Delivery.Core;
using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Api.Extensions.Mapper;

/// <summary>
/// Automapper Profile
/// </summary>
public class WaybillProfile : Profile
{
    /// <summary>
    /// Constructor
    /// </summary>
    public WaybillProfile()
    {
        CreateMap<WaybillCreateDto, Waybill>().ReverseMap();
        CreateMap<WaybillCreateDto, WaybillCreateRequest>().ReverseMap();
        CreateMap<WaybillUpdateRequest, WaybillDto>().ReverseMap();
        CreateMap<WaybillUpdateRequest, WaybillUpdateDto >().ReverseMap();
        CreateMap<Waybill, WaybillDto>().ReverseMap();
        CreateMap<WaybillDto, WaybillResponse>().ReverseMap();
        CreateMap<Waybill, WaybillResponse>().ReverseMap();

    }
}