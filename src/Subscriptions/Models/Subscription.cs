namespace Subscriptions.Models;

public class Subscription
{
    public string UserId { get; private set; }
    public bool IsStarted { get; set; }
    public DateTime? StartedAt { get; set; }

    public Subscription(string userId)
    {
        UserId = userId;
    }

    public void Start()
    {
        if (IsStarted)
            return;
        
        IsStarted = true;
        StartedAt = SystemTime.Now;
    }

    public void Stop()
    {
        if (!IsStarted)
            return;
        
        IsStarted = false;
        StartedAt = null;
    }
}