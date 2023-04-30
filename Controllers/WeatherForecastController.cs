using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseManagementAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly CMSContext _appContext;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, CMSContext appContext)
    {
        _logger = logger;
        _appContext = appContext;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("test")]
    public async Task test()
    {
        CmsUser[] users;
        users = await _appContext.CmsUser.Where(x => x.Id <= 3).ToArrayAsync();
        _appContext.CmsUser.RemoveRange(users);
        await _appContext.SaveChangesAsync();
    }
}
