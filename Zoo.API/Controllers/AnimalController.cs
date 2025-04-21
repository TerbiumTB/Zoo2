using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using Zoo.Domain.Models;
using Zoo.App.Animals;

namespace Zoo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnimalController : ControllerBase
{
    // private readonly ILogger<AnimalController> _logger;

    // public AnimalController(ILogger<AnimalController> logger)
    // {
    //     _logger = logger;
    // }
    private readonly IAnimalService _animalService;

    public AnimalController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("[action]")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var animal = _animalService.GetById(id);

        if (animal is null) return NotFound();
        
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(animal, options);
        
        return Ok(json);
    }

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var animals = _animalService.GetAll();
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(animals, options);
        return Ok(json);
    }
    

    [HttpPost("[action]")]
    public IActionResult Create([FromQuery] string nickName, [FromQuery] Species species, [FromQuery] DateOnly birthday, [FromQuery] Food favoriteFood)
    {
        _animalService.Create(nickName, species, birthday, favoriteFood);
        
        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("[action]")]
    public IActionResult Delete([FromQuery] Guid id)
    {
        return _animalService.Delete(id) ? Ok() : BadRequest();
    }
    // public IActionResult Delete([FromQuery] Guid id)
    // {
    //     
    // }
    
}