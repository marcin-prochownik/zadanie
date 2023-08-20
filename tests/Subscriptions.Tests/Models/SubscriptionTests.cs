using Subscriptions.Models;

namespace Subscriptions.Tests.Models;

public class SubscriptionTests
{
    [Fact]
    public void WhenCreatingNewSubscriptionExpectSubscriptionToNotBeStarted()
    {
        // Arrange
        var subscription = new Subscription();
        
        // Act
        var isStarted = subscription.IsStarted;
        
        // Assert
        Assert.False(isStarted);
    }
    
    [Fact]
    public void WhenStartingSubscriptionExpectSubscriptionToBeStarted()
    {
        // Arrange
        var subscription = new Subscription();
        
        // Act
        subscription.Start();
        var isStarted = subscription.IsStarted;
        
        // Assert
        Assert.True(isStarted);
    }

    [Fact]
    public void WhenStartingSubscriptionExpectStartedAtToBeSet()
    {
        using var systemTimeMock = new SystemTimeMock();
        
        // Arrange
        var subscription = new Subscription();
        systemTimeMock.Set(new DateTime(2023, 8, 20));
        
        // Act
        subscription.Start();
        
        // Assert
        Assert.Equal(new DateTime(2023, 8, 20), subscription.StartedAt);
    }

    [Fact]
    public void WhenStartingSubscriptionWhichIsAlreadyStartedExpectActionToBeIdempotent()
    {
        using var systemTimeMock = new SystemTimeMock();
        
        // Arrange
        var subscription = new Subscription();
        systemTimeMock.Set(new DateTime(2023, 8, 20));
        subscription.Start();
        systemTimeMock.Set(new DateTime(2023, 8, 23));
        
        // Act
        subscription.Start();
        
        // Assert
        Assert.Equal(new DateTime(2023, 8, 20), subscription.StartedAt);
    }
    
    [Fact]
    public void WhenStoppingSubscriptionExpectSubscriptionToBeStopped()
    {
        // Arrange
        var subscription = new Subscription();
        subscription.Start();
        
        // Act
        subscription.Stop();
        
        // Assert
        Assert.False(subscription.IsStarted);
    }

    [Fact]
    public void WhenStoppingSubscriptionExpectStartedAtToBeReset()
    {
        // Arrange
        var subscription = new Subscription();
        subscription.Start();
        
        // Act
        subscription.Stop();
        
        // Assert
        Assert.Null(subscription.StartedAt);       
    }

    [Fact]
    public void WhenStoppingSubscriptionWhichIsAlreadyStoppedExpectActionToBeIdempotent()
    {
        // Arrange
        var subscription = new Subscription();
        
        // Act
        subscription.Stop();
        
        // Assert
        Assert.False(subscription.IsStarted);
        Assert.Null(subscription.StartedAt);       
    }
}