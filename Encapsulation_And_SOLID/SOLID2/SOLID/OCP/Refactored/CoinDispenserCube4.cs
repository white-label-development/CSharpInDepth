using System.IO.Ports;

namespace SOLID.OCP.Refactored
{
    public class CoinDispenserCube4 : Device, IDevice
    {
        public CoinDispenserCube4()
        {
            Port = new SerialPort
            {
                BaudRate = 9600,
                Parity = Parity.Space,
                Handshake = Handshake.None
            };
        }

        public SerialPort Port { get; }

        public string Find()
        {            
            foreach (string portName in SerialPort.GetPortNames())
            {
                //test if device is can be connected
                Port.Write("special code");
                if (Port.ReadByte() == 0)
                    return portName;
            }
            return null;
        }

        public override void Accept(IDeviceVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
