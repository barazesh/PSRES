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




        static Timer timer = new Timer(60000);

        static Meter[] Meters = new Meter[2];

                          
        static void Main(string[] args)
        {
            timer.Elapsed += oneMinuteMark;

            //instantiate the meters


            Meters[0].Id = 1;
            Meters[0].SerialCode = 205;
            Meters[0].MeterDataReady += MeterDataHandler;

            Meters[1].Id = 2;
            Meters[1].SerialCode = 206;
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

        private static void SensorDataHandler(bool recived)
        {
            throw new NotImplementedException();
        }

        private static void MeterDataHandler(bool recived)
        {
            switch (recived)
            {
                case true:
                    //add to previous data

                    break;
                case false:
                    //do nothing

                    break;
            }
        }

        private static void oneMinuteMark(object sender, ElapsedEventArgs e)
        {
            //add data to database

            using (var context = new PSRESContext())
            {

                // add a new entry to timedate table 


                // add sensor recordings


                //add meter recordings

                //save changes
                context.SaveChanges();
            }
        }




    }
}
