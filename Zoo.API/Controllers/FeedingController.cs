using Microsoft.AspNetCore.Mvc;
using Zoo.App.Feeding;
using Zoo.Domain.Models;

namespace Zoo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedingController : ControllerBase
{
    // private readonly ILogger<AnimalController> _logger;

    // public AnimalController(ILogger<AnimalController> logger)
    // {
    //     _logger = logger;
    // }
    private readonly IFeedingOrganizationService _feedingOrganization;

    public FeedingController(IFeedingOrganizationService feedingOrganization)
    {
        _feedingOrganization = feedingOrganization;
    }


    [HttpPost("[action]")]
    public IActionResult Feed(Guid animalId)
    {
        if (_feedingOrganization.Feed(animalId))
        {
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("[action]")]
    public IActionResult FeedAll()
    {
        _feedingOrganization.FeedAll();
        return Ok();
    }

    [HttpPatch("[action]")]
    public IActionResult UpdateFeedingInterval([FromQuery] Guid animalId, [FromQuery] TimeSpan interval)
    {
        if (_feedingOrganization.UpdateFeedingInterval(animalId, interval)) return Ok();

        return BadRequest();
    }

    [HttpPatch("[action]")]
    public IActionResult UpdateFeedingFoodType([FromQuery] Guid animalId, [FromQuery] Food foodType)
    {
        if (_feedingOrganization.UpdateFeedingFoodType(animalId, foodType)) return Ok();
        return BadRequest();
    }

    [HttpDelete("[action]")]
    public IActionResult DeleteFeedingPlan([FromQuery] Guid animalId)
    {
        if (_feedingOrganization.DeleteFeedingPlan(animalId)) return Ok();
        return BadRequest();
    }

    [HttpPost("[action]")]
    public IActionResult CreateFeedingPlan([FromQuery] Guid animalId,
        [FromQuery] TimeSpan interval, [FromQuery] Food foodType)
    {
        if (_feedingOrganization.SetFeedingPlan(animalId, interval, foodType)) return Ok();
        return BadRequest();
    }
}