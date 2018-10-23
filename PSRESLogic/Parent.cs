using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    class Parent
    {
        public int Id { get; set; }
        public int Zone { get; set; }
        public Lamp[] LampsUnderCover { get; set; }
        public SensoringStation[] SensoringStationsUnderCover { get; set; }
        public int Position { get; set; }
        public int recievedSensorDatalenght { get; set; }

        public void readSensorData()
        {
            SerialPort sp = new SerialPort(SerialPort.GetPortNames()[1], 115200, Parity.None, 8, StopBits.One);
            sp.Open();
            sp.DataReceived += sensorDataReceivedEventHandler;

            byte[] message = { (byte)((Id << 6)+2) };
            sp.Write(message, 0, 1);


        }

        private void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            byte[] buffer=new byte[recievedSensorDatalenght];
            sp.Read(buffer, 0,recievedSensorDatalenght);
            
        }
    }
}
