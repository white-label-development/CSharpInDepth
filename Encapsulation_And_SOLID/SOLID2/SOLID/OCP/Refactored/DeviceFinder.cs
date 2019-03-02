namespace SOLID.OCP.Refactored
{
    public class DeviceFinder
    {
        private readonly IDevice _device;

        public DeviceFinder(IDevice device)
        {
            _device = device;
        }

        public string Find()
        {
            return _device.Find();
        }
    }
}
