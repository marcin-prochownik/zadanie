using Subscriptions.Models;

namespace Subscriptions.Data;

internal class SubscriptionRepository : ISubscriptionRepository
{
    public Subscription GetFor(string userId)
    {
        return new Subscription();
    }
}