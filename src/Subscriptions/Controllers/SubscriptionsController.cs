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

    /// <summary>
    /// Starts new subscription for an user. If subscription doesn't exist it will be created.
    /// If subscription is already started, then no changes are made.
    /// </summary>
    /// <param name="userId">User which subscription should be started.</param>
    /// <returns>200 - OK</returns>
    [HttpPost]
    [Route("{userId}/start")]
    public IActionResult Start(string userId)
    {
        try
        {
            _subscriptionService.StartForUser(userId);

            return new OkResult();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error while starting subscription for user {userId}", userId);

            return new StatusCodeResult(500);
        }
    }
    
    /// <summary>
    /// Stops user's subscription. If subscription doesn't exist, then 404 is returned.
    /// </summary>
    /// <param name="userId">User which subscription should be stopped.</param>
    /// <returns>
    /// 200 - OK
    /// 400 - Subscription doesn't exist
    /// </returns>
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
