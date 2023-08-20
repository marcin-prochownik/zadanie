using Subscriptions.Data;
using Subscriptions.Models;

namespace Subscriptions.Services;

public class SubscriptionService
{
    private readonly ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }

    public void StartForUser(string userId)
    {
        var subscription = GetSubscription(userId);
        subscription.Start();
        
        _subscriptionRepository.Save(subscription);
    }

    public void StopForUser(string userId)
    {
        var subscription = GetSubscription(userId);
        subscription.Stop();
        
        _subscriptionRepository.Save(subscription);
    }

    private Subscription GetSubscription(string userId)
    {
        var subscription = _subscriptionRepository.GetFor(userId);

        if (subscription == null)
            throw new SubscriptionNotFoundException();
        
        return subscription;
    }
}