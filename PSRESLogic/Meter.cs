using System;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;

namespace PSRESLogic
{
    public class Meter
    {

        //the name, which is the serial number written on the body of the meter
        public string Name { get; private set; }
        public long serialnumber { get; private set; }
        public decimal totalActiveEnergy { get; private set; }
        public decimal lastTotalActiveEnergy { get; private set; }
        public decimal activeEnergy { get; private set; }
        public decimal totalReactiveEnergy { get; private set; }
        public decimal lastTotalReactiveEnergy { get; private set; }
        public decimal reactiveEnergy { get; private set; }
        public decimal instantVoltage { get; private set; }
        public decimal instantCurrent { get; private set; }
        public decimal instantPower { get; private set; }
        public decimal instantPowerFactor { get; private set; }
        public decimal instantReactivePower { get; private set; }


        Stopwatch watch = new Stopwatch();

        //instantiate a port for communication with the meter.
        SerialPort mySerialPort1 = new SerialPort(SerialPort.GetPortNames()[1], 9600, Parity.Even, 7, StopBits.One);



        public void Read()
        {
            watch.Start();

            //subscribe the DataRecievedHandler method to DataRecieved Event
            mySerialPort1.DataReceived += (DataReceivedHandler);

            //calling the meter
            mySerialPort1.Open();
            mySerialPort1.WriteLine("/?" + serialnumber.ToString() + "!\r\n");

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
            else if (indata.Contains("1-0:1.8.0.255"))//total active energy kWh
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 9);
                totalActiveEnergy = decimal.Parse(message);
                Console.WriteLine(totalActiveEnergy);

            }
            else if (indata.Contains("1-0:3.8.0.255"))//total reactive energy kVArh
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 9);
                totalReactiveEnergy = decimal.Parse(message);
                Console.WriteLine(totalReactiveEnergy);

            }
            else if (indata.Contains("0-0:96.1.0.255"))//last 8 digits of meter serial number
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 8);
                Console.WriteLine(message);
            }
            else if (indata.Contains("1-0:32.7.0.255"))//instant voltage V
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 6);
                instantVoltage = decimal.Parse(message);
                Console.WriteLine(instantVoltage);
            }
            else if (indata.Contains("1-0:31.7.0.255"))//instant current A
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 6);
                instantCurrent = decimal.Parse(message);
                Console.WriteLine(instantCurrent);
            }
            else if (indata.Contains("1-0:15.7.0.255"))//instant active power kW
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 6);
                instantPower = decimal.Parse(message);
                Console.WriteLine(instantPower);
            }
            else if (indata.Contains("1-0:13.7.0.255"))//instant power factor
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 4);
                instantPowerFactor = decimal.Parse(message);
                Console.WriteLine(instantPowerFactor);
            }
            else if (indata.Contains("1-0:3.7.0.255"))//instant reactive power kVAr
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 6);
                instantReactivePower = decimal.Parse(message);
                Console.WriteLine(instantReactivePower);

            }
            else if (indata.Contains("96.7.10.255"))//unknown
            {
                
                string message = indata.Substring(indata.IndexOf("(")+1, 12);
                Console.WriteLine(message);

            }
            else if (indata.Contains("96.54.0.255"))//unknown
            {
                string message = indata.Substring(indata.IndexOf("(") + 1, 12);
                Console.WriteLine(message);

            }
            else //receiving the last line of readout
            {
                watch.Stop();
                long time = watch.ElapsedMilliseconds;
                Console.WriteLine(time);
            }
            File.AppendAllText(@"C:\Users\MRB\Documents\new.txt", indata);
            //Console.WriteLine(indata);
        }
        public Meter(string name, long serial)
        {
            Name = name;
            serialnumber = serial;
        }


    }
}

