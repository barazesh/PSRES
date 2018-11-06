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


namespace consoletest
{
    class Program
    {
        static byte[] buffer = new byte[18];
        static Parent parent = new Parent();
        static SensorRecording[] sr = new SensorRecording[3];
        static TimeDate timeDate = new TimeDate();
        static SensoringStation[] sensoringStations = new SensoringStation[3];





        static void Main(string[] args)
        {
          /* using (var context= new PSRESContext())
            {
                timeDate.year = DateTime.Now.Year;
                timeDate.month= (byte)DateTime.Now.Month;
                timeDate.day = (byte)DateTime.Now.Day;
                timeDate.hour= (byte)DateTime.Now.Hour;
                timeDate.minute = (byte)DateTime.Now.Minute;
                context.Dates.Add(timeDate);

                for (int i = 0; i < 3; i++)
                {
                    sensoringStations[i] = new SensoringStation();
                    sensoringStations[i].ParentId = 1;
                    sensoringStations[i].ParentPin = i;
                    sensoringStations[i].PositionId = 1;
                    sensoringStations[i].Zone = 1;

                }
                context.SensoringStations.AddRange(sensoringStations);
                context.SaveChanges();


            }*/


            SerialPort myport = new SerialPort(SerialPort.GetPortNames()[2], 115200, Parity.None, 8,StopBits.One);
            myport.DataReceived += sensorDataRecievedHandler;
            myport.Open();
            Console.ReadKey();
            myport.Close();

            


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
            addsensordata(sr);

            foreach (var b in buffer)
            {
                File.AppendAllText(@"C:\Users\MRB\Documents\sensordata.csv", Convert.ToString(b,2)+",");

            }

            File.AppendAllText(@"C:\Users\MRB\Documents\sensordata.csv", "\r\n");

            }

        private static void addsensordata(SensorRecording[] sensorRecording)
        {
            using (var context=new PSRESContext())
            {
                context.SensorRecordings.AddRange(sensorRecording);
                context.SaveChanges();

            }
        }
    }
}
