using Subscriptions.Models;

namespace Subscriptions.Data;

public interface ISubscriptionRepository
{
    Subscription GetFor(string userId);
    
    void Save(Subscription subscription);
}