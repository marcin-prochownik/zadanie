namespace Subscriptions.Models;

public class Subscription
{
    public string UserId { get; private set; }
    public bool IsStarted => StartedAt != null;
    public DateTime? StartedAt { get; private set; }

    public Subscription(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(userId));
        
        UserId = userId;
    }

    public Subscription(string userId, DateTime? startedAt)
        : this(userId)
    {
        StartedAt = startedAt;
    }

    public void Start()
    {
        if (IsStarted)
            return;
        
        StartedAt = SystemTime.UtcNow;
    }

    public void Stop()
    {
        if (!IsStarted)
            return;
        
        StartedAt = null;
    }
}