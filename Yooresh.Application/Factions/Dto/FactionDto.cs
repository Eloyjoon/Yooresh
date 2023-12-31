using AutoMapper;
using Yooresh.Application.Common.Mappings;
using Yooresh.Domain.Entities.Factions;

namespace Yooresh.Application.Factions.Dto;

public class FactionDto:IMapFrom<Faction>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<string> AdvantagesList { get; set; }
    public List<string> DisadvantagesList { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Faction, FactionDto>()
            .ReverseMap();
    }
}