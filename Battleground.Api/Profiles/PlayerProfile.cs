using AutoMapper;
using Battleground.Repositories.Entities;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;

namespace Battleground.Api.Profiles
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Players, PlayerDto>();
            CreateMap<PlayerInputModel, Players>();
        }

    }
}