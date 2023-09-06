using AutoMapper;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Alterations.Entities;

namespace SuitSupply.Infrastructure.MappingProfiles;
public class AlterationFormMappingProfile : Profile
{
    public AlterationFormMappingProfile()
    {
        CreateMap<AlterationFormDTO, AlterationForm>()
            .ForMember(
                dest => dest.Id,
                opt => opt.MapFrom(src => src.Id)
            )
            .ForMember(
                dest => dest.Suit,
                opt => opt.Ignore()
            )
            .ForMember(
                dest => dest.AlterationInstructions,
                opt => opt.MapFrom(src => src.AlterationInstructions)
            );
    }
}
