namespace SOLID.OCP.Refactored
{
    public abstract class Device
    {
        public abstract void Accept(IDeviceVisitor visitor);
    }
}
