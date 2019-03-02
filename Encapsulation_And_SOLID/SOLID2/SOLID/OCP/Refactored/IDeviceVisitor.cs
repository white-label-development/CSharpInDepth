namespace SOLID.OCP.Refactored
{
    public interface IDeviceVisitor
    {
        void Visit(BillDispenserEcdm billDispenser);
        void Visit(CoinDispenserCube4 coinDispenser);
    }
}
