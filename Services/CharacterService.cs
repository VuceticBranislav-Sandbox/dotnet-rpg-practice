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
                var characters = await _context.Characters!.Where(c => true).ToListAsync();
                response.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
                response.Success = true;
                response.Message = "Success GetAllCharacters";
                return response;
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