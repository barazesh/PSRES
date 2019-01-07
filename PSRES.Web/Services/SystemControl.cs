using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PSRES.Web.ViewModels;
using PSRESLogic;
using System;
using System.IO;
using System.IO.Ports;
using System.Timers;
using PSRESData.Entities;
using PSRESData;
using System.Linq;

namespace PSRES.Web.Services
{
    public class SystemControl : IController
    {
        public SystemControl(IHostingEnvironment _hosting,
                             PSRESContext context)
        {
            var lampfilepath = Path.Combine(_hosting.ContentRootPath, @"Services\Lamps.json");
            var metersfilepath = Path.Combine(_hosting.ContentRootPath, @"Services\meters.json");
            //var parentsfilepath = Path.Combine(_hosting.ContentRootPath, @"Services\parents.json");



            Lamps = JsonConvert.DeserializeObject<Lamp[]>(File.ReadAllText(lampfilepath));
            //Parents = JsonConvert.DeserializeObject<Parent[]>(File.ReadAllText(parentsfilepath));
            Meters = JsonConvert.DeserializeObject<Meter[]>(File.ReadAllText(metersfilepath));

            foreach (var meter in Meters)
            {
                meter.MeterDataReady += MeterDataHandler;
            }
            MetersPort.DataReceived += Meters[0].DataReceivedHandler;
            MetersPort.Open();
            Meters[0].Read(MetersPort);
            timer.Elapsed += OneMinuteMark;
            timer.Start();

            _Hosting = _hosting;
            this.context = context;
        }

        private void OneMinuteMark(object sender, ElapsedEventArgs e)
        {

                // add a new entry to timedate table 
                var newtime = new TimeDateEntity()
                {
                    year = (byte)(DateTime.Now.Year - 2000),
                    month = (byte)DateTime.Now.Month,
                    day = (byte)DateTime.Now.Day,
                    hour = (byte)DateTime.Now.Hour,
                    minute = (byte)DateTime.Now.Minute
                };
                context.Dates.Add(newtime);
                context.SaveChanges();


                // add sensor recordings


                //add meter recordings
                foreach (var m in Meters)
                {
                    MeterRecordingEntity meterdata = m.GetDataForDataBase();
                    meterdata.TimeDateId = newtime.Id;
                    context.MeterRecordings.Add(meterdata);

                    m.Reset();
                }

                //save changes
                context.SaveChanges();
                Console.WriteLine("Saved To DataBase");
            
        }

        Parent[] Parents = new Parent[7];

        static SerialPort TTLPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
        static SerialPort ZigbeePort = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);
        static SerialPort MetersPort = new SerialPort("COM3", 9600, Parity.Even, 7, StopBits.One);
        private Timer timer = new Timer(60000);

        public IHostingEnvironment _Hosting { get; }

        #region LampControl
        Lamp[] Lamps = new Lamp[26];


        public void ChangeFrequency(int index, byte frequency)
        {
            //change one lamp's switching frequency
            int zone = 1;
            zone = Lamps[index - 1].Zone;

            var message = Lamps[index - 1].changeFreqency(frequency);
            byte[] Zmessage =
                    {
                        0xFD, 0x02,
                        0x57, 0x3B,
                        message[0],message[1]
                    };
            switch (zone)
            {
                case 1:
                    TTLPort.Open();
                    TTLPort.Write(message, 0, 2);
                    TTLPort.Close();
                    break;
                case 2:
                    ZigbeePort.Open();
                    ZigbeePort.Write(Zmessage, 0, 6);
                    ZigbeePort.Close();
                    break;
                case 3:
                    Zmessage[2] = 0xB5;
                    Zmessage[3] = 0xCE;
                    ZigbeePort.Open();
                    ZigbeePort.Write(Zmessage, 0, 6);
                    ZigbeePort.Close();
                    break;
            }

        }

        public void ChangeFrequency(byte frequency)
        {
            //change all lamps switching frequency at once
        }

        public void Dim(int index, byte dutycycle)
        {
            //change one lamp's duty cycle
            int zone = 1;
            zone = Lamps[index - 1].Zone;

            var message = Lamps[index - 1].Dim(dutycycle);
            byte[] Zmessage =
                    {
                            0xFD, 0x02,
                            0x57, 0x3B,
                            message[0],message[1]
                        };
            switch (zone)
            {
                case 1:
                    TTLPort.Open();
                    TTLPort.Write(message, 0, 2);
                    TTLPort.Close();
                    break;
                case 2:
                    ZigbeePort.Open();
                    ZigbeePort.Write(Zmessage, 0, 6);
                    ZigbeePort.Close();
                    break;
                case 3:
                    Zmessage[2] = 0xB5;
                    Zmessage[3] = 0xCE;
                    ZigbeePort.Open();
                    ZigbeePort.Write(Zmessage, 0, 6);
                    ZigbeePort.Close();
                    break;
            }
        }

        public void Dim(byte dutycycle)
        {
            //change all lamps duty cycle at once


            byte[] message = { 0, dutycycle };
            byte[] Zmessage =
                    {
                            0xFD, 0x02,
                            0x57, 0x3B,
                            message[0],message[1]
                        };
            //zone 1:
            TTLPort.Open();
            TTLPort.Write(message, 0, 2);
            TTLPort.Close();
            //zone 2:
            ZigbeePort.Open();
            ZigbeePort.Write(Zmessage, 0, 6);
            ZigbeePort.Close();
            //zone 3:
            Zmessage[2] = 0xB5;
            Zmessage[3] = 0xCE;
            ZigbeePort.Open();
            ZigbeePort.Write(Zmessage, 0, 6);
            ZigbeePort.Close();

        }

        #endregion

        #region Meter

        Meter[] Meters = new Meter[5];
        int selectedmeterid;
        private readonly PSRESContext context;

        private void MeterDataHandler(int meterId)
        {
            MetersPort.DataReceived -= Meters[selectedmeterid].DataReceivedHandler;
            selectedmeterid = meterId;
            if (meterId == 5)
            {
                selectedmeterid = 0;
            }
            MetersPort.DataReceived += Meters[selectedmeterid].DataReceivedHandler;
            Meters[selectedmeterid].Read(MetersPort);
        }


        public MeterViewModel[] GetrealTimeMetersData()
        {
            MeterViewModel[] realtimemeterdata = new MeterViewModel[5];
            for (int i = 0; i < 5; i++)
            {
                decimal[] output = Meters[i].GetRealTimeData();
                realtimemeterdata[i] = new MeterViewModel();
                realtimemeterdata[i].ActivePower = output[0];
                realtimemeterdata[i].ReactivePower = output[1];
                realtimemeterdata[i].Current = output[2];
                realtimemeterdata[i].Frequency = output[3];
                realtimemeterdata[i].Voltage = output[4];
                realtimemeterdata[i].PowerFactor = output[5];
                realtimemeterdata[i].SerialCode = Meters[i].SerialCode;
                realtimemeterdata[i].Name = Meters[i].Name;
            }

            return realtimemeterdata;
        }


        #endregion

        #region Sensors

        public SensorViewModel GetrealTimeSensorsData(int zone, int parentNumber)
        {
            SensorViewModel sensor = new SensorViewModel();
            Parent parent = Parents.Where(p =>
                            p.Zone == zone 
                            && p.parentNumber == parentNumber).First();
            for (int i = 0; i < 3; i++)
            {
                sensor.Sensor[i] = parent.Sensor[i].GetLatestData();
            }

            return sensor;
        }
        #endregion

    }
}