using System;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace PSRESLogic
{
    public class Meter
    {

        //the name, which is the serial number written on the body of the meter
        public int Id { get; set; }
        public string Name { get; private set; }
        public long serialnumber { get; private set; }

        private bool reciveCompeleted;
        private List<string> recievedData;
        private string[] recievedstring=new string[11];
        private StringBuilder sb = new StringBuilder();



        private decimal totalActiveEnergy;
        private decimal lastTotalActiveEnergy;
        private decimal activeEnergy;
        private decimal totalReactiveEnergy;
        private decimal lastTotalReactiveEnergy;
        private decimal reactiveEnergy;
        private decimal instantVoltage;
        private decimal instantCurrent;
        private decimal instantPower;
        private decimal instantPowerFactor;
        private decimal instantReactivePower;
        private decimal instantFrequency;
        private string voltageCuttBegining;
        private string voltageReturn;
                                                  

        Stopwatch watch = new Stopwatch();

    



        public void Read(SerialPort mySerialPort1)
        {
            reciveCompeleted = false;
            watch.Start();

            //subscribe the DataRecievedHandler method to DataRecieved Event
            mySerialPort1.DataReceived += (DataReceivedHandler);

            //calling the meter
            
            mySerialPort1.WriteLine("/?" + serialnumber.ToString() + "!\r\n");
            while (!reciveCompeleted) { }
            Console.WriteLine(recievedstring);
            extractData();

        }

        private void extractData()
        {
            string pattern = @"\([0-9]*.[0-9]{2}\*|\([0-9].[0-9]{2}\)|\([0-9]{8}\)|\([0-9]{12}\)";
            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);
            char[] charstoTrim = { '(', '*', ')' };
            for (int i = 0; i < 11; i++)
            {
                recievedstring[i] = matches[i].Value.Trim(charstoTrim);

                switch (i)
                {
                    case 0:
                        totalActiveEnergy = decimal.Parse(recievedstring[i]);
                        activeEnergy = 1000 * (lastTotalActiveEnergy - totalActiveEnergy);
                        lastTotalActiveEnergy = totalActiveEnergy;
                        break;
                    case 1:
                        totalReactiveEnergy = decimal.Parse(recievedstring[i]);
                        reactiveEnergy = 1000 * (lastTotalReactiveEnergy - totalReactiveEnergy);
                        lastTotalReactiveEnergy = totalReactiveEnergy;

                        break;
                    case 2:
                        //serial number
                        break;
                    case 3:
                        instantVoltage = decimal.Parse(recievedstring[i]);
                        break;
                    case 4:
                        instantCurrent = decimal.Parse(recievedstring[i]);
                        break;
                    case 5:
                        instantPower = decimal.Parse(recievedstring[i]);
                        break;
                    case 6:
                        instantPowerFactor = decimal.Parse(recievedstring[i]);
                        break;
                    case 7:
                        instantFrequency = decimal.Parse(recievedstring[i]);
                        break;
                    case 8:
                        instantReactivePower = decimal.Parse(recievedstring[i]);
                        break;
                    case 9:
                        voltageCuttBegining = recievedstring[i];
                        break;
                    case 10:
                        voltageReturn = recievedstring[i];
                        break;
                    default:
                        break;
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
            else if (indata.Contains(char.ConvertFromUtf32(0x03)))
            {
                reciveCompeleted = true;
                sb.Append(indata);

            }
            else
            {
                sb.Append(indata);
            }
            
        }

        

        public Meter(string name, long serial)
        {
            Name = name;
            serialnumber = serial;
            recievedData = new List<string>();
        }




    }
}

