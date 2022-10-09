using AutoMapper;
using Battleground.Models.Dtos;
using Battleground.Repositories.Entities;

namespace Battleground.Api.Profiles;

public class BattleProfile : Profile
{
    public BattleProfile()
    {
        CreateMap<Battles, BattleDto>();
    }
}
