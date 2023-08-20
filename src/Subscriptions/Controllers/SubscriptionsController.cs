using Microsoft.AspNetCore.Mvc;

namespace Subscriptions.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ILogger<SubscriptionsController> _logger;

    public SubscriptionsController(ILogger<SubscriptionsController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Route("{userId}/start")]
    public IActionResult Start(string userId)
    {
        return new OkResult();
    }
    
    [HttpPost]
    [Route("{userId}/stop")]
    public IActionResult Stop(string userId)
    {
        return new OkResult();
    }
}