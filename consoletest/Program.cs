using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSRES.Data;
using PSRESLogic;
using System.IO;
using System.Timers;
using PSRES.Data.Entities;

namespace consoletest
{
    class Program
    {
        static SerialPort MetersPort = new SerialPort(SerialPort.GetPortNames()[1], 9600, Parity.Even, 7, StopBits.One);
        //static SerialPort SensorsPort = new SerialPort(SerialPort.GetPortNames()[2], 115200, Parity.None, 8, StopBits.One);



        static byte[] buffer = new byte[18];
        static Parent parent = new Parent(2);




        static Timer timer = new Timer(60000);

        static Meter[] Meters = new Meter[2];

                          
        static void Main(string[] args)
        {
            Console.WriteLine(SerialPort.GetPortNames().ToString());
            Console.WriteLine("select port for meter reading:");
            MetersPort.PortName = Console.ReadLine();
            
            timer.Elapsed += oneMinuteMark;

            //instantiate the meters

            using (var context = new PSRESContext())
            {
                DatabaseSeeder seeder = new DatabaseSeeder(context);
                seeder.Seed();
                var meters= context.Meters.ToArray();
                for (int i = 0; i < Meters.Length; i++)
                {
                    Meters[i] = new Meter();
                    Meters[i].Id = meters[i].Id;
                    Meters[i].SerialCode = meters[i].Serialcode;
                    Meters[i].MeterDataReady += MeterDataHandler;
                }

            }

            parent.SensorDataReady += SensorDataHandler;
            MetersPort.Open();
            Meters[0].Read(MetersPort);
            timer.Start();
            Console.ReadKey();


        }

        private static void SensorDataHandler(bool recived)
        {
            throw new NotImplementedException();
        }

        private static void MeterDataHandler(int meterId)
        {
            Console.WriteLine(Meters[meterId - 1].ToString()); 
            //this handler calls the next meter to read data
            int i;
            switch (meterId==Meters.Length)
            {
                case true://the last meter in the array has been reached so the first one should be read next
                    i = 0;
                    break;
                case false:
                    i = meterId;//not the last meter in the list. (meterId is 1 based while the index is zero based)
                    break;
            }
        }

        private static void oneMinuteMark(object sender, ElapsedEventArgs e)
        {
            //add data to database

            using (var context = new PSRESContext())
            {

                // add a new entry to timedate table 
                var newtime = new TimeDateEntity() {
                    year = DateTime.Now.Year,
                    month = (byte)DateTime.Now.Month,
                    day = (byte)DateTime.Now.Day,
                    hour=(byte)DateTime.Now.Hour,
                    minute=(byte)DateTime.Now.Minute                
                };
                context.Dates.Add(newtime);


                // add sensor recordings


                //add meter recordings
                foreach (var m in Meters)
                {
                    MeterRecordingEntity meterdata= m.GetDataForDataBase();
                    meterdata.TimeDateId = newtime.Id;
                    context.MeterRecordings.Add(meterdata);

                    m.Reset();
                }

                //save changes
                context.SaveChanges();


            }
        }




    }
}
