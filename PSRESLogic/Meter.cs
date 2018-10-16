using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace PSRESLogic
{
    public class Meter
    {

        //the name, which is the serial number written on the body of the meter
        public string Name { get; private set; }
        Stopwatch watch = new Stopwatch();
        //instantiate a port for communication with the meter.
        SerialPort mySerialPort1 = new SerialPort(SerialPort.GetPortNames()[1], 9600, Parity.Even, 7, StopBits.One);
        public void Read()
        {
            watch.Start();

            //subscribe the DataRecievedHandler method to DataRecieved Event
            mySerialPort1.DataReceived += (DataReceivedHandler);

            //generate the string required to call the meter
            //string call = "/?" + Name + "!\r\n";

            //calling the meter
            mySerialPort1.Open();
            //mySerialPort1.WriteLine(call);
            mySerialPort1.WriteLine("/?" + Name + "!\r\n");

        }


        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            if (indata.Contains("/TFC5"))//receiving the first message from the meter
            {
                //the Acknowledgment message
                string ack = Char.ConvertFromUtf32(0x06) + "050\r\n";

                //sending the acknowledgment message
                sp.WriteLine(ack);

            }
            else if (indata.Contains("0-0:96.54.0.255"))//receiving the last line of readout
            {
                watch.Stop();
                long time = watch.ElapsedMilliseconds;
                Console.WriteLine(time);

                //sp.WriteLine(Name);
                
            }
            //File.AppendAllText(@"C:\Users\MRB\Documents\new.txt", indata);
            //Console.WriteLine(indata);
        }
        public Meter(string name)
        {
            Name = name;
        }


    }
}

