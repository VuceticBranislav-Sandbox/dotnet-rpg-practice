using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_rpg_practice.Models;

namespace dotnet_rpg_practice.Services
{
    public class CharacterService : ICharacterService
    {
        public ServiceResponse<Character> GetAllCharacters()
        {
            {
                return new ServiceResponse<Character>
                {
                    Data = new Character(),
                    Success = true,
                    Message = "No data provided."
                };
            }
        }
    }
}