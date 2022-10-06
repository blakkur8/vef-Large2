using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
