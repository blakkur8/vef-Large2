using AutoMapper;
using Battleground.Models.Dtos;
using Battleground.Repositories.Entities;

namespace Battleground.Api.Profiles;

public class InventoryProfile : Profile
{
    public InventoryProfile()
    {
        CreateMap<PlayerInventories, PlayerInventoriesDto>();
    }
}
