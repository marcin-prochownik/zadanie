using Microsoft.AspNetCore.Mvc;
using Subscriptions.Data;
using Subscriptions.Models;
using Subscriptions.Services;

namespace Subscriptions.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionService _subscriptionService;
    private readonly ILogger<SubscriptionsController> _logger;

    public SubscriptionsController(ISubscriptionService subscriptionService,
        ILogger<SubscriptionsController> logger)
    {
        _subscriptionService = subscriptionService;
        _logger = logger;
    }

    [HttpPost]
    [Route("{userId}/start")]
    public IActionResult Start(string userId)
    {
        try
        {
            _subscriptionService.StartForUser(userId);

            return new OkResult();
        }
        catch (SubscriptionNotFoundException)
        {
            return new NotFoundResult();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while starting subscription for user {userId}", userId);

            return new StatusCodeResult(500);
        }
    }
    
    [HttpPost]
    [Route("{userId}/stop")]
    public IActionResult Stop(string userId)
    {
        try
        {
            _subscriptionService.StopForUser(userId);

            return new OkResult();
        }
        catch (SubscriptionNotFoundException)
        {
            return new NotFoundResult();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while stopping subscription for user {userId}", userId);

            return new StatusCodeResult(500);
        }
    }
}
