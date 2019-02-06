using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    public class TTLParent : Parent
    {

        public TTLParent(byte parentnumber, int Delay) : base(parentnumber, Delay)
        {
            readRequestMessage= new byte[2];
            readRequestMessage[0] = (byte)((parentNumber << 6) + 56);
            readRequestMessage[1] = (byte)~readRequestMessage[0];
        }

        public override void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            //Console.WriteLine("TTL sensor data received event fired");
            SerialPort sp = (SerialPort)sender;

            sp.Read(buffer, 0, 18);

            TranslateRecivedData(buffer);
            timer.Start();
        }
    }
    }
