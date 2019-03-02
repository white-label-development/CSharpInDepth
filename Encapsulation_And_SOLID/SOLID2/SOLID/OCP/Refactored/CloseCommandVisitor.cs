using System.IO.Ports;

namespace SOLID.OCP.Refactored
{
    public class CloseCommandVisitor : IDeviceVisitor
    {
        public void Visit(BillDispenserEcdm billDispenser)
        {
            //custom settings of port
            SerialPort port = billDispenser.Port;
            port.Write(new byte[] { 0x03 }, 0, 1);
        }

        public void Visit(CoinDispenserCube4 coinDispenser)
        {
            //custom settings of port
            SerialPort port = coinDispenser.Port;
            port.Write(new byte[] { 0x12 }, 0, 1);
        }
    }
}
