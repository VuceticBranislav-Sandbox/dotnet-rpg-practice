using AutoMapper;
using dotnet_rpg_practice.Dtos.Character;
using dotnet_rpg_practice.Models;

namespace dotnet_rpg
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Character, GetCharacterDto>();
        }
    }
}