namespace NDummy.Tests.CustomTypes
{
    public interface ICustomInterface
    {
        int InterfaceID { get; set; }
    }

    public class CustomInterfaceImpl : ICustomInterface
    {
        public int InterfaceID { get; set; }
    }
}
