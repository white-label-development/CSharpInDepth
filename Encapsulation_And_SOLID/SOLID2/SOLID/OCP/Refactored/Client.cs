namespace SOLID.OCP.Refactored
{
    public class Client
    {
        void Logic()
        {
            var device = new BillDispenserEcdm();
            device.Close();
        }
    }
}
