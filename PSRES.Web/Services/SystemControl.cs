using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using PSRES.Web.ViewModels;
using PSRESLogic;
using System;
using System.IO;
using System.IO.Ports;


namespace PSRES.Web.Services
{
    public class SystemControl:IController
    {
        public SystemControl(IHostingEnvironment _hosting)
        {
            var lampfilepath = Path.Combine(_hosting.ContentRootPath, @"Services\Lamps.json");
            var metersfilepath = Path.Combine(_hosting.ContentRootPath, @"Services\meters.json");
            var parentsfilepath = Path.Combine(_hosting.ContentRootPath, @"Services\parents.json");



            Lamps = JsonConvert.DeserializeObject<Lamp[]>(File.ReadAllText(lampfilepath));
            Parents = JsonConvert.DeserializeObject<Parent[]>(File.ReadAllText(parentsfilepath));
            Meters = JsonConvert.DeserializeObject<Meter[]>(File.ReadAllText(metersfilepath));

            foreach (var meter in Meters)
            {
                meter.MeterDataReady += MeterDataHandler;
            }
            MetersPort.DataReceived += Meters[0].DataReceivedHandler;
            Meters[0].Read(MetersPort);

            _Hosting = _hosting;
        }

        private void MeterDataHandler(int meterId)
        {
            MetersPort.DataReceived -= Meters[meterId - 1].DataReceivedHandler;
            int tempId = meterId;
            if (tempId == Meters.Length)
            {
                tempId = 0;
            }
            MetersPort.DataReceived += Meters[tempId].DataReceivedHandler;
            Meters[tempId].Read(MetersPort);
        }

        //initiate the lamps
        Lamp[] Lamps = new Lamp[26];
        Parent[] Parents = new Parent[7];
        Meter[] Meters = new Meter[5];

        static SerialPort TTLPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
        static SerialPort ZigbeePort = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);
        static SerialPort MetersPort = new SerialPort("COM3", 9600, Parity.Even, 7, StopBits.One);


        public IHostingEnvironment _Hosting { get; }

        #region LampControl
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

        public MeterViewModel[] GetrealTimeMetersData()
        {
            MeterViewModel[] realtimemeterdata = new MeterViewModel[5];
            for (int i = 0; i < 5; i++)
            {
                decimal[] output = Meters[i].GetRealTimeData();
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
        #region MyRegion
        //static SerialPort MetersPort = new SerialPort(SerialPort.GetPortNames()[1], 9600, Parity.Even, 7, StopBits.One);
        ////static SerialPort SensorsPort = new SerialPort(SerialPort.GetPortNames()[2], 115200, Parity.None, 8, StopBits.One);



        //static byte[] buffer = new byte[18];
        //static Parent parent = new Parent(2);

        //static int counter;


        //static Timer timer = new Timer(60000);

        //static Meter[] Meters = new Meter[2];


        //static void Main(string[] args)
        //{
        //    Console.WriteLine(MetersPort.PortName);
        //    Console.WriteLine("Press any key to begin");
        //    Console.ReadKey();

        //    timer.Elapsed += oneMinuteMark;

        //    //instantiate the meters

        //    using (var context = new PSRESContext())
        //    {
        //        DataBaseSeeder seeder = new DataBaseSeeder(context);
        //        seeder.Seed();
        //        var meters = context.Meters.ToArray();
        //        for (int i = 0; i < Meters.Length; i++)
        //        {
        //            Meters[i] = new Meter();
        //            Meters[i].Id = meters[i].Id;
        //            Meters[i].SerialCode = meters[i].Serialcode;
        //            Meters[i].MeterDataReady += MeterDataHandler;
        //        }



        //    }

        //    parent.SensorDataReady += SensorDataHandler;
        //    MetersPort.Open();
        //    MetersPort.DataReceived += Meters[0].DataReceivedHandler;
        //    Meters[0].Read(MetersPort);
        //    timer.Start();
        //    string input = "";
        //    while (!input.Equals("q"))
        //    {
        //        input = Console.ReadLine();

        //    }



        //}



        //private static void SensorDataHandler(bool recived)
        //{
        //    throw new NotImplementedException();
        //}

        //private static void MeterDataHandler(int meterId)
        //{
        //    //Console.WriteLine(Meters[meterId - 1].ToString());

        //    MetersPort.DataReceived -= Meters[meterId - 1].DataReceivedHandler;
        //    //this handler calls the next meter to read data
        //    int i = meterId;//not the last meter in the list. (meterId is 1 based while the index is zero based)
        //    if (meterId == Meters.Length)//the last meter in the array has been reached so the first one should be read next
        //    {
        //        i = 0;
        //        Console.WriteLine(counter);
        //        counter++;
        //    }
        //    MetersPort.DataReceived += Meters[i].DataReceivedHandler;
        //    Meters[i].Read(MetersPort);
        //}

        //private static void oneMinuteMark(object sender, ElapsedEventArgs e)
        //{
        //    //add data to database

        //    using (var context = new PSRESContext())
        //    {

        //        // add a new entry to timedate table 
        //        var newtime = new TimeDateEntity()
        //        {
        //            year = DateTime.Now.Year,
        //            month = (byte)DateTime.Now.Month,
        //            day = (byte)DateTime.Now.Day,
        //            hour = (byte)DateTime.Now.Hour,
        //            minute = (byte)DateTime.Now.Minute
        //        };
        //        context.Dates.Add(newtime);
        //        context.SaveChanges();


        //        // add sensor recordings


        //        //add meter recordings
        //        foreach (var m in Meters)
        //        {
        //            MeterRecordingEntity meterdata = m.GetDataForDataBase();
        //            meterdata.TimeDateId = newtime.Id;
        //            context.MeterRecordings.Add(meterdata);

        //            m.Reset();
        //        }

        //        //save changes
        //        context.SaveChanges();
        //        Console.WriteLine("Saved To DataBase");


        //    }
        //} 
        #endregion

    }
}