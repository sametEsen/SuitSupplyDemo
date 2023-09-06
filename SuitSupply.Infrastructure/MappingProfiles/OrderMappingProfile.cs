using AutoMapper;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Orders.Entities;

namespace SuitSupply.Infrastructure.MappingProfiles;
public class OrderMappingProfile : Profile
{
	public OrderMappingProfile() 
	{
		CreateMap<OrderDTO, Order>()
			.ForMember(
				dest => dest.Id,
				opt => opt.MapFrom(src => src.Id)
			)
			.ForMember(
				dest => dest.Form,
				opt => opt.Ignore()
			)
			.ForMember(
				dest => dest.IsPaid,
				opt => opt.MapFrom(src => src.IsPaid)
			)
			.ForMember(
				dest => dest.IsStarted,
				opt => opt.MapFrom(src => src.IsStarted)
			);
	}
}
