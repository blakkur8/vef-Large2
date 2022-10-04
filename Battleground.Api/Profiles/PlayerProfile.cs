using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Battleground.Repositories.Entities;
using Battleground.Models.Dtos;

namespace Battleground.Api.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Players, PlayerDto>();
        }

    }
}