using Meama.Common.AutoMapper;

namespace Application.TurnamentResult.MappingProfiles;

using Infrastructure.Database.Entities;

public class TurnamentResultResponseMappingProfile : MapperProfile
{
    public TurnamentResultResponseMappingProfile()
    {
        CreateMap<TurnamentResultDto, TurnamentResult>()
            .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(o => o.IsWinner, opt => opt.MapFrom(src => src.IsWinner))
            .ForMember(o => o.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(o => o.PrizeAmount, opt => opt.MapFrom(src => src.PrizeAmount))
            .ForMember(o => o.PersonalNumber, opt => opt.MapFrom(src => src.PersonalNumber))
            .ForMember(o => o.CurrentBalance, opt => opt.MapFrom(src => src.CurrentBalance));

        CreateMap<TurnamentResult, TurnamentResultDto>()
            .ForMember(o => o.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(o => o.IsWinner, opt => opt.MapFrom(src => src.IsWinner))
            .ForMember(o => o.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(o => o.PrizeAmount, opt => opt.MapFrom(src => src.PrizeAmount))
            .ForMember(o => o.PersonalNumber, opt => opt.MapFrom(src => src.PersonalNumber))
            .ForMember(o => o.CurrentBalance, opt => opt.MapFrom(src => src.CurrentBalance));
    }
}