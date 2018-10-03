using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace PSRESLogic
{
    class Meter
    {

        //the name, which is the serial number written on the body of the meter
        public int Name { get; private set; }

        public void Read()
        {
            //instantiate a port for communication with the meter. the first couple of messages are sent with baud rate 300
            SerialPort mySerialPort1 = new SerialPort("COM5", 300, Parity.Even, 7, StopBits.One);
            mySerialPort1.Handshake = Handshake.None;

            //subscribe the DataRecievedHandler method to DataRecieved Event
            mySerialPort1.DataReceived += (DataReceivedHandler);

            //generate the string required to call the meter
            string call = "/?" + Name.ToString() + "!\r\n";

            //calling the meter
            mySerialPort1.Open();
            mySerialPort1.WriteLine(call);

            //Console.ReadKey();
            //mySerialPort1.Close();


        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            if (indata.Contains("/TFC5"))//receiving the first message from the meter
            {
                //creating the Acknowledgment message
                string ack = Char.ConvertFromUtf32(Convert.ToInt32("06", 16)) + "050\r\n";

                //sending the acknowledgment message
                sp.WriteLine(ack);

                //changing the baud rate to 9600 for faster communication after 200 milliseconds
                Thread.Sleep(200);
                sp.BaudRate = 9600;
            }
            else if (indata.Contains("1-0:0.0.0.255"))//receiving the last line of readout
            {
                Thread.Sleep(200);
                sp.BaudRate = 300;
                sp.WriteLine("/?18119713646209!\r\n");
                
            }
            File.AppendAllText(@"C:\Users\MRB\Documents\new.txt", indata);
            Console.WriteLine(indata);
        }


    }
}

