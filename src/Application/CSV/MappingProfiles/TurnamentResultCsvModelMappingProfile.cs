using Application.CSV.Models;
using Meama.Common.AutoMapper;

namespace Application.CSV.MappingProfiles;

using Infrastructure.Database.Entities;

public class TurnamentResultCsvModelMappingProfile : MapperProfile
{
    public TurnamentResultCsvModelMappingProfile()
    {
        CreateMap<TurnamentResultCsvModel, TurnamentResult>()
            .ForMember(o => o.Id, opt => opt.Ignore())
            .ForMember(o => o.IsWinner, opt => opt.MapFrom(src => src.IsWinner))
            .ForMember(o => o.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(o => o.PrizeAmount, opt => opt.MapFrom(src => src.PrizeAmount))
            .ForMember(o => o.PersonalNumber, opt => opt.MapFrom(src => src.PersonalNumber))
            .ForMember(o => o.CurrentBalance, opt => opt.MapFrom(src => src.CurrentBalance));

        CreateMap<TurnamentResult, TurnamentResultCsvModel>()
            .ForMember(o => o.IsWinner, opt => opt.MapFrom(src => src.IsWinner))
            .ForMember(o => o.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(o => o.PrizeAmount, opt => opt.MapFrom(src => src.PrizeAmount))
            .ForMember(o => o.PersonalNumber, opt => opt.MapFrom(src => src.PersonalNumber))
            .ForMember(o => o.CurrentBalance, opt => opt.MapFrom(src => src.CurrentBalance));
    }
}