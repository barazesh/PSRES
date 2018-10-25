using System;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;

namespace PSRESLogic
{
    public class Meter
    {

        //the name, which is the serial number written on the body of the meter
        public int Id { get; set; }
        public string Name { get; private set; }
        public long serialnumber { get; private set; }
        public bool reciveCompeleted { get; private set; }
        public List<string> recievedData { get; private set; }


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
        public decimal instantFrequency { get; private set; }
        public string voltageCuttBegining { get; private set; }
        public string voltageReturn { get; private set; }


        Stopwatch watch = new Stopwatch();

    



        public void Read(SerialPort mySerialPort1)
        {
            reciveCompeleted = false;
            watch.Start();

            //subscribe the DataRecievedHandler method to DataRecieved Event
            mySerialPort1.DataReceived += (DataReceivedHandler);

            //calling the meter
            
            mySerialPort1.WriteLine("/?" + serialnumber.ToString() + "!\r\n");
            while (!reciveCompeleted)
            {

            }
            extractData();

        }

        private void extractData()
        {
            foreach (var item in recievedData)
            {
                if (item.Contains("1-0:1.8.0.255"))//total active energy kWh
                {
                     totalActiveEnergy = decimal.Parse(item.Substring(item.IndexOf("(") + 1, 9));
                    activeEnergy = 1000*(lastTotalActiveEnergy - totalActiveEnergy);
                    lastTotalActiveEnergy = totalActiveEnergy;

                }
                else if (item.Contains("1-0:3.8.0.255"))//total reactive energy kVArh
                {
                    totalReactiveEnergy = decimal.Parse(item.Substring(item.IndexOf("(") + 1, 9));

                    reactiveEnergy = 1000 * (lastTotalReactiveEnergy - totalReactiveEnergy);
                    lastTotalReactiveEnergy = totalReactiveEnergy;

                }

                else if (item.Contains("1-0:32.7.0.255"))//instant voltage V
                {
                    instantVoltage = decimal.Parse(item.Substring(item.IndexOf("(") + 1, 6));
                }
                else if (item.Contains("1-0:31.7.0.255"))//instant current A
                {
                    instantCurrent = decimal.Parse(item.Substring(item.IndexOf("(") + 1, 6));
                }
                else if (item.Contains("1-0:15.7.0.255"))//instant active power kW
                {
                    instantPower = decimal.Parse(item.Substring(item.IndexOf("(") + 1, 6));
                }
                else if (item.Contains("1-0:13.7.0.255"))//instant power factor
                {
                    instantPowerFactor = decimal.Parse(item.Substring(item.IndexOf("(") + 1, 4));
                }
                else if (item.Contains("1-0:3.7.0.255"))//instant reactive power kVAr
                {
                    instantReactivePower = decimal.Parse(item.Substring(item.IndexOf("(") + 1, 6));
                }
                else if (item.Contains("1-0:14.7.0.255"))//instant Frequency Hz
                {
                    instantFrequency = decimal.Parse(item.Substring(item.IndexOf("(") + 1, 5));
                }
                else if (item.Contains("96.7.10.255"))//beginning date and time of the last voltage fall out
                {
                    voltageCuttBegining = item.Substring(item.IndexOf("(") + 1, 12);
                }
                else if (item.Contains("96.54.0.255"))//voltage return date and time
                {
                    voltageReturn = item.Substring(item.IndexOf("(") + 1, 12);
                }

            }
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
            else if (indata.Contains("!"))
            {
                reciveCompeleted = true;
                recievedData.Add(indata);

            }
            else
            {
                
                recievedData.Add(indata);
            }
            
        }

        private void DataReceivedHandler1(object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            string message;
            if (indata.Contains("/TFC5"))//receiving the first message from the meter
            {
                //the Acknowledgment message
                string ack = Char.ConvertFromUtf32(0x06) + "050\r\n";

                //sending the acknowledgment message
                sp.WriteLine(ack);

            }
            else if (indata.Contains("1-0:1.8.0.255"))//total active energy kWh
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 9);
                totalActiveEnergy = decimal.Parse(message);
                activeEnergy = lastTotalActiveEnergy - totalActiveEnergy;
                lastTotalActiveEnergy = totalActiveEnergy;
                //Console.WriteLine(totalActiveEnergy);

            }
            else if (indata.Contains("1-0:3.8.0.255"))//total reactive energy kVArh
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 9);
                totalReactiveEnergy = decimal.Parse(message);
                reactiveEnergy = lastTotalReactiveEnergy - totalReactiveEnergy;
                lastTotalReactiveEnergy = totalReactiveEnergy;
                //Console.WriteLine(totalReactiveEnergy);

            }
            else if (indata.Contains("0-0:96.1.0.255"))//last 8 digits of meter serial number
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 8);
                //Console.WriteLine(message);
            }
            else if (indata.Contains("1-0:32.7.0.255"))//instant voltage V
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 6);
                instantVoltage = decimal.Parse(message);
                //Console.WriteLine(instantVoltage);
            }
            else if (indata.Contains("1-0:31.7.0.255"))//instant current A
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 6);
                instantCurrent = decimal.Parse(message);
                //Console.WriteLine(instantCurrent);
            }
            else if (indata.Contains("1-0:15.7.0.255"))//instant active power kW
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 6);
                instantPower = decimal.Parse(message);
                //Console.WriteLine(instantPower);
            }
            else if (indata.Contains("1-0:13.7.0.255"))//instant power factor
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 4);
                instantPowerFactor = decimal.Parse(message);
                //Console.WriteLine(instantPowerFactor);
            }
            else if (indata.Contains("1-0:3.7.0.255"))//instant reactive power kVAr
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 6);
                instantReactivePower = decimal.Parse(message);
                //Console.WriteLine(instantReactivePower);

            }
            else if (indata.Contains("1-0:14.7.0.255"))//instant Frequency Hz
            {
                message = indata.Substring(indata.IndexOf("(") + 1, 5);
                instantFrequency = decimal.Parse(message);
                //Console.WriteLine(instantReactivePower);

            }
            else if (indata.Contains("96.7.10.255"))//beginning date and time of the last voltage fall out
            {
                voltageCuttBegining = indata.Substring(indata.IndexOf("(") + 1, 12);
                //Console.WriteLine(message);
            }
            else if (indata.Contains("96.54.0.255"))//voltage return date and time
            {
                voltageReturn = indata.Substring(indata.IndexOf("(") + 1, 12);
                //Console.WriteLine(message);

            }
            else //receiving the last line of readout
            {
                watch.Stop();
                long time = watch.ElapsedMilliseconds;
                Console.WriteLine(time);
                reciveCompeleted = true;

            }
            // File.AppendAllText(@"C:\Users\MRB\Documents\new.txt", (indata+"\r\n"));
            Console.WriteLine(indata);
        }

        public Meter(string name, long serial)
        {
            Name = name;
            serialnumber = serial;
        }


    }
}

