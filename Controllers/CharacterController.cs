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

    [HttpGet]
    public async Task<ActionResult<List<ServiceResponse<GetCharacterDto>>>> Get()
    {
        return Ok(await _characterService.GetAllCharacters());
    }
}
