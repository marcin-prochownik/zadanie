namespace Subscriptions;

public static class SystemTime
{
    [ThreadStatic]
    private static DateTime? _systemTimeOverride;
    
    public static DateTime UtcNow => _systemTimeOverride ?? DateTime.UtcNow;
    
    public static void Set(DateTime? dateTime)
    {
        _systemTimeOverride = dateTime;
    }
}
