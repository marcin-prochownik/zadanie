namespace Subscriptions.Models;

public class Subscription
{
    public bool IsStarted { get; private set; }
    public DateTime? StartedAt { get; private set; }

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