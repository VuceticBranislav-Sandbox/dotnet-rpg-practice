using dotnet_rpg_practice.Models;
using dotnet_rpg_practice.Services;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_rpg_practice.Controllers;

[ApiController]
[Route("[controller]")]
public class CharacterController : ControllerBase
{
    private readonly ILogger<CharacterController> _logger;
    private readonly ICharacterService _service;

    public CharacterController(ILogger<CharacterController> logger, ICharacterService service)
    {
        _service = service;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<ServiceResponse<Character>> Get()
    {
        return Ok(_service.GetAllCharacters());
    }
}
