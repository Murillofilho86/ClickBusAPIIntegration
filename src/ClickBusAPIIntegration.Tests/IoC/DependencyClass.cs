namespace ClickBusAPIIntegration.Tests.IoC
{
    public class DependencyClass : IDependency
    {
        public int Value { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public int TestWriteLine(int count)
        {
            throw new System.NotImplementedException();
        }
    }
}
