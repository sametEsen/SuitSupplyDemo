using AutoMapper;
using SuitSupply.Domain.DataTransfer.Entities;
using SuitSupply.Domain.Models.Alterations.Values;

namespace SuitSupply.Infrastructure.MappingProfiles;
public class AlterationInstructionMappingProfile : Profile
{
    public AlterationInstructionMappingProfile()
    {
        CreateMap<AlterationInstructionDTO, AlterationInstruction>()
            .ForMember(
                dest => dest.Type,
                opt => opt.MapFrom(src => src.Type)
            )
            .ForMember(
                dest => dest.Description,
                opt => opt.MapFrom(src => src.Description)
            )
            .ForMember(
                dest => dest.Measurement,
                opt => opt.MapFrom(src => src.Measurement)
            );
    }
}
