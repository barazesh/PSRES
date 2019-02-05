using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PSRESLogic
{
    public class ZigbeeParent : Parent
    {
        private Timer timer = new Timer();

        public ZigbeeParent(byte parentnumber) : base(parentnumber)
        {
            readRequestMessage = new byte[6];
            readRequestMessage[0] = 0xFD;
            readRequestMessage[1] = 0x02;

            readRequestMessage[4] = (byte)((parentNumber << 6) + 56);
            readRequestMessage[5] = (byte)~readRequestMessage[0];
            
            timer.Elapsed += timerelapsed;
            timer.AutoReset = false;
        }


        private void timerelapsed(object sender, ElapsedEventArgs e)
        {
            onDataReady(true);
        }

        public override void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            Console.WriteLine("ZigBee sensor data received event fired");
            byte[] readbuffer = new byte[24];
            SerialPort sp = (SerialPort)sender;
            sp.Read(readbuffer, 0, 24);
            Array.Copy(readbuffer, 4, buffer, 0, 18);

            TranslateRecivedData(buffer);
            timer.Start();
        }
    }
}
