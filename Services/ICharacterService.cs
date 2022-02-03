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
    }
}