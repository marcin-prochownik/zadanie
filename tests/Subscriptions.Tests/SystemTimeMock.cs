namespace Subscriptions.Tests;

public class SystemTimeMock : IDisposable
{
    public void Set(DateTime? dateTime)
    {
        SystemTime.Set(dateTime);
    }
    
    public void Dispose()
    {
        SystemTime.Set(null);
    }
}