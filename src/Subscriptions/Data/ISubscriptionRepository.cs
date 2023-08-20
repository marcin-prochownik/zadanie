using Subscriptions.Models;

namespace Subscriptions.Data;

internal interface ISubscriptionRepository
{
    Subscription GetFor(string userId);
}