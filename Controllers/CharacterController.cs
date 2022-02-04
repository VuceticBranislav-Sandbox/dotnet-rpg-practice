using dotnet_rpg_practice.Dtos.Character;
using dotnet_rpg_practice.Models;
using dotnet_rpg_practice.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg_practice.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ILogger<CharacterController> _logger;
    private readonly ICharacterService _characterService;

    public CharacterController(ILogger<CharacterController> logger, ICharacterService characterService)
    {
        _characterService = characterService;
        _logger = logger;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<List<ServiceResponse<GetCharacterDto>>>> GetCharacterById(int id)
    {
        return Ok(await _characterService.GetCharacterById(id));
    }

    [HttpGet("All")]
    public async Task<ActionResult<List<ServiceResponse<GetCharacterDto>>>> GetAllCharacters()
    {
        return Ok(await _characterService.GetAllCharacters());
    }

    [HttpPost]
    public async Task<ActionResult<List<ServiceResponse<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
    {
        return Ok(await _characterService.AddCharacter(newCharacter));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<List<ServiceResponse<GetCharacterDto>>>> UpdateCharacter(int id, AddCharacterDto updateCharacter)
    {
        return Ok(await _characterService.UpdateCharacter(id, updateCharacter));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<List<ServiceResponse<GetCharacterDto>>>> RemoveCharacterById(int id)
    {
        return Ok(await _characterService.RemoveCharacterById(id));
    }
}
