using Microsoft.AspNetCore.Mvc;

using System.Text.Json;
using Zoo.Domain.Models;
using Zoo.App.Enclosures;

namespace Zoo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EnclosureController : ControllerBase
{
    // private readonly ILogger<AnimalController> _logger;

    // public AnimalController(ILogger<AnimalController> logger)
    // {
    //     _logger = logger;
    // }
    private readonly IEnclosureService _enclosureService;

    public EnclosureController(IEnclosureService enclosureService)
    {
        _enclosureService = enclosureService;
    }
    

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet("[action]")]
    public IActionResult GetById([FromQuery] Guid id)
    {
        var enclosure = _enclosureService.GetById(id);

        if (enclosure is null) return NotFound();
        
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(enclosure, options);
        
        return Ok(json);
    }

    [HttpGet("[action]")]
    public IActionResult GetAll()
    {
        var enclosures = _enclosureService.GetAll();
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(enclosures, options);
        return Ok(json);
    }
    

    [HttpPost("[action]")]
    public IActionResult Create([FromQuery] AnimalType type, [FromQuery] int capacity)
    {
        _enclosureService.Create(type, capacity);
        
        return Ok();
    }

    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("[action]")]
    public IActionResult Delete([FromQuery] Guid id)
    {
        return _enclosureService.Delete(id) ? Ok() : BadRequest();
    }
    // public IActionResult Delete([FromQuery] Guid id)
    // {
    //     
    // }
    
}