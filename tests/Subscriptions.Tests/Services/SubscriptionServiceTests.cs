using Subscriptions.Data;
using Subscriptions.Models;
using Subscriptions.Services;

namespace Subscriptions.Tests.Services;

public class SubscriptionServiceTests
{
    [Fact]
    public void WhenStartingSubscriptionWhichDoesntExistsExpectSubscriptionNotFoundException()
    {
        // Arrange
        var subscriptionRepositoryMock = Substitute.For<ISubscriptionRepository>();
        subscriptionRepositoryMock.GetFor(Arg.Any<string>()).Returns(default(Subscription));
        var subscriptionService = new SubscriptionService(subscriptionRepositoryMock);
        
        // Act
        void Action() => subscriptionService.StartForUser("user-id");

        // Assert
        Assert.Throws<SubscriptionNotFoundException>(Action);
    }
    
    [Fact]
    public void WhenStartingSubscriptionExpectSubscriptionToBeStarted()
    {
        // Arrange
        var subscriptionRepositoryMock = Substitute.For<ISubscriptionRepository>();
        subscriptionRepositoryMock.GetFor(Arg.Any<string>()).Returns(new Subscription());
        var subscriptionService = new SubscriptionService(subscriptionRepositoryMock);
        
        // Act
        subscriptionService.StartForUser("user-id");
        
        // Assert
        subscriptionRepositoryMock.Received().Save(Arg.Is<Subscription>(s => s.IsStarted));
    }

    [Fact]
    public void WhenStoppingSubscriptionWhichDoesntExistExpectSubscriptionNotFoundException()
    {
        // Arrange
        var subscriptionRepositoryMock = Substitute.For<ISubscriptionRepository>();
        subscriptionRepositoryMock.GetFor(Arg.Any<string>()).Returns(default(Subscription));
        var subscriptionService = new SubscriptionService(subscriptionRepositoryMock);
        
        // Act
        void Action() => subscriptionService.StopForUser("user-id");

        // Assert
        Assert.Throws<SubscriptionNotFoundException>(Action);     
    }
    
    [Fact]
    public void WhenStoppingSubscriptionExpectSubscriptionToBeStopped()
    {
        // Arrange
        var subscription = new Subscription();
        subscription.Start();
        
        var subscriptionRepositoryMock = Substitute.For<ISubscriptionRepository>();
        subscriptionRepositoryMock.GetFor(Arg.Any<string>()).Returns(subscription);
        var subscriptionService = new SubscriptionService(subscriptionRepositoryMock);
        
        // Act
        subscriptionService.StopForUser("user-id");
        
        // Assert
        subscriptionRepositoryMock.Received().Save(Arg.Is<Subscription>(s => !s.IsStarted));
    }
}