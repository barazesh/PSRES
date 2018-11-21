using System;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;

namespace PSRESLogic
{
    public delegate void MeterDataReadyHandler(bool recived);

    public class Meter
    {
        public int Id { get; set; }
        public long SerialCode { get; set; }


        private StringBuilder sb = new StringBuilder();


        private decimal Voltage;
        private decimal Current;
        private int ActivePower;
        private decimal PowerFactor;
        private decimal Frequency;
        private int ReactivePower;
        private bool reciveCompeleted;
        private decimal totalActiveEnergy;
        private decimal totalReactiveEnergy;
        private string voltageCuttBegining;
        private string voltageReturn;
        public event MeterDataReadyHandler MeterDataReady;
                                                  

        private Stopwatch watch = new Stopwatch();
        private Timer timer = new Timer(1100);


        public void Read(SerialPort mySerialPort1)
        {
            reciveCompeleted = false;
            sb.Clear();
            watch.Start();

            //calling the meter
            
            mySerialPort1.WriteLine("/?" + SerialCode.ToString() + "!\r\n");

        }

        private void timerelapsed(object sender, ElapsedEventArgs e)
        {

            if (reciveCompeleted)
            {
                extractData();
            }

            onDataReady(reciveCompeleted);
            ;
        }

        protected virtual void onDataReady(bool reciveCompeleted)
        {
            (MeterDataReady as MeterDataReadyHandler)?.Invoke(reciveCompeleted);
        }

        private void extractData()
        {
            string pattern = @"\([0-9]*.[0-9]{2}\*|\([0-9].[0-9]{2}\)|\([0-9]{8}\)|\([0-9]{12}\)";
            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);
            char[] charstoTrim = { '(', '*', ')' };
            for (int i = 0; i < 11; i++)
            {

                switch (i)
                {
                    case 0:
                        totalActiveEnergy = 1000 * decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 1:
                        totalReactiveEnergy = 1000 * decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 2:
                        //serial number
                        break;
                    case 3:
                        Voltage = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 4:
                        Current = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 5:
                        ActivePower = (int)(1000*decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        break;
                    case 6:
                        PowerFactor = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 7:
                        Frequency = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 8:
                        ReactivePower = (int)(1000 *decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        break;
                    case 9:
                        voltageCuttBegining = matches[i].Value.Trim(charstoTrim);
                        break;
                    case 10:
                        voltageReturn = matches[i].Value.Trim(charstoTrim);
                        break;
                    default:
                        break;
                }
            }
            
        }


        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {

            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            if (indata.Contains("/TFC5"))//receiving the first message from the meter
            {
                //the Acknowledgment message
                string ack = Char.ConvertFromUtf32(0x06) + "050\r\n";

                //sending the acknowledgment message
                sp.WriteLine(ack);
                timer.Start();


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

        public Meter()
        {
            timer.Elapsed += timerelapsed;
            timer.AutoReset = false;
        }

    }
}

