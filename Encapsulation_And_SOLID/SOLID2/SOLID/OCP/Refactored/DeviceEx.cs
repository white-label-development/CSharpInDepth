namespace SOLID.OCP.Refactored
{
    public static class DeviceEx
    {
        public static void Close(this Device device)
        {
            var visitor = new CloseCommandVisitor();
            device.Accept(visitor);
        }
    }
}
