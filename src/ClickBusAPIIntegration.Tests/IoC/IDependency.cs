namespace ClickBusAPIIntegration.Tests.IoC
{
    public interface IDependency
    {
        int Value { get; set; }
        int TestWriteLine(int count);
    }
}
