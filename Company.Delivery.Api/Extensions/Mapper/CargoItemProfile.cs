using AutoMapper;
using Company.Delivery.Api.Controllers.Waybills.Response;
using Company.Delivery.Core;
using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Api.Extensions.Mapper;

/// <summary>
/// Automapper profile
/// </summary>
public class CargoItemProfile : Profile
{
    /// <summary>
    /// constructor
    /// </summary>
    public CargoItemProfile()
    {
        CreateMap<CargoItemCreateDto, CargoItem>().ReverseMap();
        CreateMap<CargoItemUpdateDto, CargoItem>().ReverseMap();
        CreateMap<CargoItem, CargoItemDto>().ReverseMap();
        CreateMap<CargoItemDto , CargoItemResponse>().ReverseMap();
    }
}