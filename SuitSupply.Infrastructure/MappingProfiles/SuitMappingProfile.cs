using AutoMapper;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Suits.Entities;

namespace SuitSupply.Infrastructure.MappingProfiles;
public class SuitMappingProfile : Profile
{
	public SuitMappingProfile()
	{
		CreateMap<Suit, SuitDTO>()
			.ForMember(
				dest => dest.Id,
				opt => opt.MapFrom(src => src.Id)
			)
			.ForMember(
				dest => dest.Type,
				opt => opt.MapFrom(src => src.Type)
			);
	}
}
