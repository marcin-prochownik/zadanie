using Subscriptions.Models;

namespace Subscriptions.Data;

public class SubscriptionRepository : ISubscriptionRepository
{
    public Subscription GetFor(string userId)
    {
        return new Subscription(userId);
    }

    public void Save(Subscription subscription)
    {
    }
}
