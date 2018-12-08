using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSRESData;
using PSRESLogic;
using System.IO;
using System.Timers;
using PSRESData.Entities;

namespace consoletest
{
    class Program
    {
        static SerialPort SensorsPort = new SerialPort(SerialPort.GetPortNames()[2], 115200, Parity.None, 8, StopBits.One);
        static byte[] buffer = new byte[18];

        static Parent[] parents =
        {
            new Parent(1),
            new Parent(2),
            new Parent(3)
        };
        static bool datarecived;
        static int parentindex;

          
        static void Main(string[] args)
        {

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i].SensorDataReady += ShowSensrosData;

            }
            Console.WriteLine(SensorsPort.PortName);
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();

            while (true)
            {
                Console.WriteLine("Eneter the Parent Number to read Sensor data:");


                SensorsPort.DataReceived -= parents[parentindex].sensorDataReceivedEventHandler;
                parentindex = int.Parse(Console.ReadLine());
                SensorsPort.DataReceived += parents[parentindex].sensorDataReceivedEventHandler;

                parents[parentindex].readSensorData(SensorsPort);

                Console.ReadKey();

            }



        }

        private static void ShowSensrosData(bool recived)
        {
            Console.WriteLine();
            if (SensorsPort.IsOpen)
            {
                SensorsPort.Close();
            }
            datarecived = recived;
            if (recived)
            {
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Sensor Pack {i+1}");
                    Console.WriteLine(parents[parentindex].sensorsdata[i].GetLatestData().ToString());
                }

            }
            else
            {
                Console.WriteLine("No Data Recieved");
            }
        }
    }
}
