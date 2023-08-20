using System.Collections.Concurrent;
using Subscriptions.Models;

namespace Subscriptions.Data;

public class InMemorySubscriptionRepository : ISubscriptionRepository
{
    private static ConcurrentDictionary<string, SubscriptionItem> Subscriptions { get; } = new();   
    
    public Subscription? GetFor(string userId)
    {
        if (Subscriptions.TryGetValue(userId, out var subscription))
        {
            return new Subscription(subscription.UserId, subscription.StartedAt);
        }

        return null;
    }

    public void Save(Subscription subscription)
    {
        Subscriptions.TryRemove(subscription.UserId, out var _);
        
        Subscriptions.TryAdd(subscription.UserId, new SubscriptionItem
        {
            UserId = subscription.UserId,
            StartedAt = subscription.StartedAt
        });
    }

    private class SubscriptionItem
    {
        public string UserId { get; init; } = null!;
        public DateTime? StartedAt { get; init; }
    }
}
