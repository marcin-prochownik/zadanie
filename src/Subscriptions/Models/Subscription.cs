namespace Subscriptions.Models;

public class Subscription
{
    public string UserId { get; private set; }
    public bool IsStarted { get; set; }
    public DateTime? StartedAt { get; set; }

    public Subscription(string userId)
    {
        if (string.IsNullOrWhiteSpace(userId))
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(userId));
        
        UserId = userId;
    }

    public void Start()
    {
        if (IsStarted)
            return;
        
        IsStarted = true;
        StartedAt = SystemTime.UtcNow;
    }

    public void Stop()
    {
        if (!IsStarted)
            return;
        
        IsStarted = false;
        StartedAt = null;
    }
}