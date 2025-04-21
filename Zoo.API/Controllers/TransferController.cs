using Microsoft.AspNetCore.Mvc;

using Zoo.App.Animals;

namespace Zoo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransferController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public TransferController(IAnimalService animalService)
    {
        _animalService = animalService;
    }
    
    [HttpPost("[action]")]
    public IActionResult Transfer(Guid animalId, Guid enclosureId)
    {
        // try
        // {
        //     _transferService.TransferAnimal(animalId, enclosureId);
        //     return Ok();
        // }
        // catch (Exception e)
        // { 
        //     return BadRequest(e.Message);
        // }
        if (_animalService.TransferAnimal(animalId, enclosureId))
        {
            return Ok();
        }
        
        return BadRequest();
    }
}