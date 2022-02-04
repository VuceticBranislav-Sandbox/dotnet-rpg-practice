using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg_practice.Dtos.Character;
using dotnet_rpg_practice.Models;

namespace dotnet_rpg_practice.Services
{
    public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
        Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, AddCharacterDto? updateCharacter);
        Task<ServiceResponse<GetCharacterDto>> RemoveCharacterById(int id);
    }
}