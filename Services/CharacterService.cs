using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg_practice.Dtos.Character;
using dotnet_rpg_practice.Models;
using dotnet_rpg_practice.Repository;
using Microsoft.EntityFrameworkCore;

namespace dotnet_rpg_practice.Services
{
    public class CharacterService : ICharacterService
    {
        public DataContext _context { get; }
        public IMapper _mapper { get; }

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var characters = await _context.Characters!.ToListAsync();
                response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                response.Success = true;
                response.Message = "Success, GetAllCharacters.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var response = new ServiceResponse<GetCharacterDto>();

            try
            {
                var character = await _context.Characters!.FirstOrDefaultAsync(c => c.Id == id);

                if (character == null)
                {
                    response.Data = null;
                    response.Success = false;
                    response.Message = "Fail, GetCharacterById. Invalid Id";
                    return response;
                }
                response.Data = _mapper.Map<GetCharacterDto>(character);
                response.Success = true;
                response.Message = "Success, GetCharacterById.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            var response = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                if (newCharacter == null)
                {
                    response.Success = false;
                    response.Message = "Fail, AddCharacter. Invalid input data.";
                    return response;
                }

                Character addCharacter = _mapper.Map<Character>(newCharacter);
                _context.Characters!.Add(addCharacter);
                await _context.SaveChangesAsync();

                response.Data = await _context.Characters!.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();

                response.Success = true;
                response.Message = "Success, AddCharacter.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> RemoveCharacterById(int id)
        {
            // Prepare response
            var response = new ServiceResponse<GetCharacterDto>();

            try
            {
                // Get first character by id
                var character = await _context.Characters!.FirstOrDefaultAsync(c => c.Id == id);

                // Return empty object and message if there is nothing to remove
                if (character == null)
                {
                    response.Success = false;
                    response.Message = "Fail, RemoveCharacterById. Invalid Id";
                    return response;
                }

                // Remove object and update data base
                _context.Remove(character);
                await _context.SaveChangesAsync();

                // Prepare response data
                response.Data = _mapper.Map<GetCharacterDto>(character);
                response.Success = true;
                response.Message = "Success, RemoveCharacterById.";
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(int id, AddCharacterDto? updateCharacter)
        {
            var response = new ServiceResponse<GetCharacterDto>();

            try
            {
                Character? character = await _context.Characters!.FirstOrDefaultAsync(c => c.Id == id);

                if (updateCharacter == null || character == null)
                {
                    response.Success = false;
                    response.Message = "Fail, AddCharacterDto. Character not found.";
                    return response;
                }

                if (updateCharacter != null && updateCharacter.Name != null) character.Name = updateCharacter.Name;
                character.HitPoints = updateCharacter!.HitPoints;
                character.Strength = updateCharacter.Strength;
                character.Defense = updateCharacter.Defense;
                character.Intelligence = updateCharacter.Intelligence;
                character.Class = updateCharacter.Class;

                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}