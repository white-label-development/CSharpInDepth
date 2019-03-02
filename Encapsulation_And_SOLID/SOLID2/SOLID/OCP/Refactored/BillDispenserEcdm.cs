using System.IO.Ports;

namespace SOLID.OCP.Refactored
{
    public class BillDispenserEcdm : Device, IDevice
    {
        public BillDispenserEcdm()
        {
            Port = new SerialPort
            {
                BaudRate = 4800,
                Parity = Parity.Mark,
                Handshake = Handshake.RequestToSendXOnXOff
            };
        }

        public SerialPort Port { get; }

        public string Find()
        {            
            foreach (string portName in SerialPort.GetPortNames())
            {
                //test if device is can be connected
                Port.Write("special code");
                if (Port.ReadByte() == 120)
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
