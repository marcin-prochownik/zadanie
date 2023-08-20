namespace Subscriptions.Services;

public interface ISubscriptionService
{
    void StartForUser(string userId);
    void StopForUser(string userId);
}