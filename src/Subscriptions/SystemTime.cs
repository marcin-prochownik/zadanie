namespace Subscriptions;

public static class SystemTime
{
    [ThreadStatic]
    private static DateTime? _systemTimeOverride;
    
    public static DateTime Now => _systemTimeOverride ?? DateTime.Now;
    
    public static void Set(DateTime? dateTime)
    {
        _systemTimeOverride = dateTime;
    }
}