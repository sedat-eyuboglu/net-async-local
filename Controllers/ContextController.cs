using Microsoft.AspNetCore.Mvc;

namespace net_async_local.Controllers;

[ApiController]
[Route("[controller]")]
public class ContextController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<ContextController> _logger;
    private readonly ContextProvider contextProvider;
    private readonly SomeOtherService service;

    public ContextController(ILogger<ContextController> logger, ContextProvider contextProvider, SomeOtherService service)
    {
        _logger = logger;
        this.contextProvider = contextProvider;
        this.service = service;
    }

    [HttpGet("Context/{id}")]
    public async Task<string> Context(string id)
    {
        int[] waits = {100, 200, 500, 750, 150, 850, 400, 210, 400};
        
        contextProvider.CreateScope($"some scope {id}");
        var rnd = new Random();
        var wait = waits[rnd.Next(waits.Length)];
        await Task.Delay(wait);
        return $"waited {wait} ---> {service.SomeMethod()}";
    }

    [HttpGet("ContextSamples")]
    public IEnumerable<string> ContextSamples()
    {
        for(var i = 1; i < 100; i++)
        {
            yield return $"http://localhost:5021/Context/Context/{i}";
        }
    }
}
