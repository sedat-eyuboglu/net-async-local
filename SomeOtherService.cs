public class SomeOtherService
{
    private readonly ContextProvider contextProvider;
    public SomeOtherService(ContextProvider contextProvider)
    {
        this.contextProvider = contextProvider;
    }

    public string SomeMethod() 
    {
        return $"{contextProvider.CurrentScope.ScopeName}";
    }
}