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
    public delegate void MeterDataReadyHandler(bool recived, MeterRecording data);

    public class Meter
    {

        //the name, which is the serial number written on the body of the meter
        public int Id { get; set; }
        public string Name { get; set; }
        public long Serialcode { get; set; }
        public List<MeterRecording> Recording { get; set; }

        private StringBuilder sb = new StringBuilder();


        private bool reciveCompeleted;
        private decimal totalActiveEnergy;
        private decimal lastTotalActiveEnergy;
        private decimal totalReactiveEnergy;
        private decimal lastTotalReactiveEnergy;
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
            
            mySerialPort1.WriteLine("/?" + Serialcode.ToString() + "!\r\n");

        }

        private void timerelapsed(object sender, ElapsedEventArgs e)
        {
            MeterRecording mr = new MeterRecording();

            if (reciveCompeleted)
            {
                extractData(mr);
            }

            onDataReady(reciveCompeleted, mr);
            ;
        }

        protected virtual void onDataReady(bool reciveCompeleted, MeterRecording mr)
        {
            (MeterDataReady as MeterDataReadyHandler)?.Invoke(reciveCompeleted, mr);
        }

        private void extractData(MeterRecording mr)
        {
            string pattern = @"\([0-9]*.[0-9]{2}\*|\([0-9].[0-9]{2}\)|\([0-9]{8}\)|\([0-9]{12}\)";
            MatchCollection matches = Regex.Matches(sb.ToString(), pattern);
            char[] charstoTrim = { '(', '*', ')' };
            for (int i = 0; i < 11; i++)
            {

                switch (i)
                {
                    case 0:
                        totalActiveEnergy = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        mr.activeEnergy = 1000 * (lastTotalActiveEnergy - totalActiveEnergy);
                        lastTotalActiveEnergy = totalActiveEnergy;
                        break;
                    case 1:
                        totalReactiveEnergy = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        mr.reactiveEnergy = 1000 * (lastTotalReactiveEnergy - totalReactiveEnergy);
                        lastTotalReactiveEnergy = totalReactiveEnergy;

                        break;
                    case 2:
                        //serial number
                        break;
                    case 3:
                        mr.voltage = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 4:
                        mr.current = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 5:
                        mr.activePower = (int)(1000*decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        break;
                    case 6:
                        mr.powerFactor = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 7:
                        mr.frequency = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 8:
                        mr.reactivePower = (int)(1000 *decimal.Parse(matches[i].Value.Trim(charstoTrim)));
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

