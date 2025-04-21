using Microsoft.AspNetCore.Mvc;
using Zoo.App.Statistics;

namespace Zoo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IStatisticsService _statisticsService;

    public StatisticsController(IStatisticsService statisticsService)
    {
        _statisticsService = statisticsService;
    }

    [HttpGet("[action]")]
    public IActionResult GetAnimalCount()
    {
        return Ok(_statisticsService.GetTotalAnimalCount());
    }

    [HttpGet("[action]")]
    public IActionResult GetEnclosureCount()
    {
        return Ok(_statisticsService.GetTotalEnclosureCount());
    }

    [HttpGet("[action]")]
    public IActionResult GetHungryAnimalCount()
    {
        return Ok(_statisticsService.GetTotalHungryAnimalCount());
    }
}