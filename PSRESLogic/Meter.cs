using System;
using System.IO.Ports;
using System.Diagnostics;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using PSRES.Data.Entities;
using System.Linq;

namespace PSRESLogic
{
    public delegate void MeterDataReadyHandler(int meterId);

    public class Meter
    {
        public int Id { get; set; }
        public long SerialCode { get; set; }

        private StringBuilder sb = new StringBuilder();


        private List<decimal> Voltage = new List<decimal>();
        private List<decimal> Current = new List<decimal>();
        private List<decimal> PowerFactor = new List<decimal>();
        private List<decimal> Frequency = new List<decimal>();
        private List<decimal> Calcpower= new List<decimal>();

        private int peakActivePower;
        private int peakReactivePower;

        private int ActivePower;
        private int ReactivePower;

        private decimal[] totalActiveEnergy= new decimal[2];
        private decimal[] totalReactiveEnergy= new decimal[2];

        private string voltageCuttBegining;
        private string voltageReturn;

        public event MeterDataReadyHandler MeterDataReady;
        private bool reciveCompeleted;


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

            onDataReady(Id);
            
        }

        protected virtual void onDataReady(int meterid)
        {
            (MeterDataReady as MeterDataReadyHandler)?.Invoke(meterid);
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
                        totalActiveEnergy[1] = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 1:
                        totalReactiveEnergy[1] = decimal.Parse(matches[i].Value.Trim(charstoTrim));
                        break;
                    case 2:
                        //serial number
                        break;
                    case 3:
                        
                        Voltage.Add(decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        break;
                    case 4:
                        Current.Add(decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        break;
                    case 5:
                        ActivePower = (int)(1000 * decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        peakActivePower = MAX(ActivePower,peakActivePower);
                        break;
                    case 6:
                        PowerFactor.Add(decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        break;
                    case 7:
                        Frequency.Add(decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        break;
                    case 8:
                        ReactivePower = (int)(1000 * decimal.Parse(matches[i].Value.Trim(charstoTrim)));
                        peakReactivePower = MAX(ReactivePower, peakReactivePower);
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
            Calcpower.Add(Voltage.Last()*Current.Last());
            
        }

        private int MAX(int v1, int v2)
        {
            int result=v2;
            if (v1 >= v2)
            {
                result = v1;
            }
            return result;
        }

        public MeterRecordingEntity GetDataForDataBase()
        {
            MeterRecordingEntity mr = new MeterRecordingEntity();

            mr.activeEnergy = (int)(1000*(totalActiveEnergy[1] - totalActiveEnergy[0]));
            mr.reactiveEnergy = (int)(1000 * (totalReactiveEnergy[1] - totalReactiveEnergy[0]));
            mr.current = Current.Average();
            mr.frequency = Frequency.Average();
            mr.voltage = Voltage.Average();
            mr.powerFactor = PowerFactor.Average();
            mr.peakActivePower = ActivePower;
            mr.peakReactivePower = ReactivePower;
            mr.MeterId = Id;

            return mr;
        }

        public decimal[] GetRealTimeData()
        {
            decimal[] realTimeData = new decimal[8];

            realTimeData[0] = totalActiveEnergy[1];
            realTimeData[1] = totalReactiveEnergy[1];
            realTimeData[2] = Current.Last();
            realTimeData[3] = Frequency.Last();
            realTimeData[4] = Voltage.Last();
            realTimeData[5] = PowerFactor.Last();
            realTimeData[6] = peakActivePower;
            realTimeData[7] = peakReactivePower;

            return realTimeData;
        }

        public void Reset()
        {
            totalActiveEnergy[0]=totalActiveEnergy[1];
            totalReactiveEnergy[0] = totalReactiveEnergy[1];
            Current.Clear();
            Voltage.Clear();
            PowerFactor.Clear();
            Frequency.Clear();
            peakActivePower = 0;
            peakReactivePower = 0;

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
            //Console.WriteLine(indata);
            
        }

        public override string ToString()
        {
            StringBuilder newsb = new StringBuilder();
            newsb.AppendLine("Serial Code: " + SerialCode.ToString());
            newsb.AppendLine("Peak Active Power: "+peakActivePower.ToString());
            newsb.AppendLine("Peak Reactive Power: " + peakReactivePower.ToString());
            newsb.AppendLine("Active Energy: " + totalActiveEnergy[1].ToString());
            newsb.AppendLine("Reactive Energy: " + totalReactiveEnergy[1].ToString());
            newsb.AppendLine("Voltage: " + Voltage.Last().ToString());
            newsb.AppendLine("Current: " + Current.Last().ToString());
            newsb.AppendLine("Power Factor: " + PowerFactor.Last().ToString());
            newsb.AppendLine("Frequency: " + Frequency.Last().ToString());

            return newsb.ToString();
        }

        public Meter()
        {
            timer.Elapsed += timerelapsed;
            timer.AutoReset = false;
        }
    }
}

