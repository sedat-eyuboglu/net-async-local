public class ContextProvider
{
    public ContextProvider()
    { }
    private static readonly AsyncLocal<LogContext> scopeNameHolder = new();

    public LogContext CreateScope(string name)
    {
        scopeNameHolder.Value = new()
        {
            ScopeName = name
        };
        return scopeNameHolder.Value;
    }

    public LogContext CurrentScope
    {
        get
        {
            return scopeNameHolder.Value ?? new();
        }
    }
}