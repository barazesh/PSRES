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

namespace consoletest
{
    class Program
    {
        static SerialPort myport = new SerialPort(SerialPort.GetPortNames()[2], 115200, Parity.None, 8, StopBits.One);


        static byte[] buffer = new byte[18];
        static Parent parent = new Parent(2);
        static SensorRecording[] sr = new SensorRecording[3];
        static SensoringStation[] sensoringStations = new SensoringStation[3];


        static TimeDate timeDate = new TimeDate();

        static Timer timer = new Timer(60000);

        static Meter[] Meters = new Meter[2];

                          
        static void Main(string[] args)
        {
            timer.Elapsed += oneMinuteMark;

            //instantiate the meters


            Meters[0].Id = 1;
            Meters[0].Serialcode = 205;
            Meters[0].MeterDataReady += MeterDataHandler;

            Meters[1].Id = 2;
            Meters[1].Serialcode = 206;
            Meters[1].MeterDataReady += MeterDataHandler;

            parent.SensorDataReady += SensorDataHandler;



            while (true)
            {
                //read meters
                foreach (Meter m in Meters)
                {
                    m.Read(myport);
                }

                //read sensors
            }


        }

        private static void SensorDataHandler(bool recived, SensorRecording[] recording)
        {
            throw new NotImplementedException();
        }

        private static void MeterDataHandler(bool recived, MeterRecording data)
        {
            throw new NotImplementedException();
        }

        private static void oneMinuteMark(object sender, ElapsedEventArgs e)
        {
            //add data to database

            using (var context = new PSRESContext())
            {

                // add a new entry to timedate table 
                timeDate.year = DateTime.Now.Year;
                timeDate.month = (byte)DateTime.Now.Month;
                timeDate.day = (byte)DateTime.Now.Day;
                timeDate.hour = (byte)DateTime.Now.Hour;
                timeDate.minute = (byte)DateTime.Now.Minute;
                context.Dates.Add(timeDate);

                // add sensor recordings


                //add meter recordings

                //save changes
                context.SaveChanges();
            }
        }

        private static void sensorDataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            bool reliable = sp.BytesToRead == 18; ;


                sp.Read(buffer, 0, sp.BytesToRead);
                sr=parent.extractSensorData(buffer);
                File.AppendAllText(@"C:\Users\MRB\Documents\sensordata.csv", DateTime.Now.ToString()+",");

            for (int i = 0; i < 3; i++)
            {
                sr[i].SensoringStationId = i+10;
                sr[i].TimeDateId = 4;
                sr[i].Reliable = reliable;
                File.AppendAllText(@"C:\Users\MRB\Documents\sensordata.csv", sr[i].ToString());
            }

            foreach (var b in buffer)
            {
                File.AppendAllText(@"C:\Users\MRB\Documents\sensordata.csv", Convert.ToString(b,2)+",");

            }

            File.AppendAllText(@"C:\Users\MRB\Documents\sensordata.csv", "\r\n");

            }


    }
}
