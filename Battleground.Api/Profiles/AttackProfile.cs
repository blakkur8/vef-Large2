using AutoMapper;
using Battleground.Models.Dtos;
using Battleground.Models.InputModels;
using Battleground.Repositories.Entities;

namespace Battleground.Api.Profiles;

public class AttackProfile : Profile
{
    public AttackProfile()
    {
        CreateMap<Attacks, AttackDto>();
        CreateMap<AttackInputModel, Attacks>();
    }
}
