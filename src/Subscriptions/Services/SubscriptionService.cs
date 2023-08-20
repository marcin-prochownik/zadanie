using Subscriptions.Data;

namespace Subscriptions.Services;

internal class SubscriptionService
{
    private ISubscriptionRepository _subscriptionRepository;

    public SubscriptionService(ISubscriptionRepository subscriptionRepository)
    {
        _subscriptionRepository = subscriptionRepository;
    }
    
    void StartForUser(string userId)
    {
        var subscription = _subscriptionRepository.GetFor(userId);
        
    }
    
    void StopForUser(string userId)
    {
    }
}