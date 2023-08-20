using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute.ExceptionExtensions;
using Subscriptions.Controllers;
using Subscriptions.Models;
using Subscriptions.Services;

namespace Subscriptions.Tests.Controllers;

public class SubscriptionsControllerTests
{
    [Fact]
    void WhenStoppingSubscriptionWhichDoesntExistExpectNotFoundToBeReturned()
    {
        // Arrange
        var logger = Substitute.For<ILogger<SubscriptionsController>>();
        var subscriptionService = Substitute.For<ISubscriptionService>();
        subscriptionService.When(x => x.StopForUser(Arg.Any<string>()))
            .Do(x => throw new SubscriptionNotFoundException());
        var controller = new SubscriptionsController(subscriptionService, logger);
        
        // Act
        var result = controller.Stop("user-id");
        
        // Assert
        Assert.IsType<NotFoundResult>(result);
    }
}