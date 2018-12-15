using Newtonsoft.Json;
using PSRESLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;

namespace consoletest
{
    class Program
    {
        static int parentIndex;
        static byte[] buffer = new byte[18];

        static Parent[] parents = new Parent[7];

        static void Main(string[] args)
        {
            SerialPort TTLPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
            SerialPort ZigbeePort = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);

            //initiate the parents
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            parents=JsonConvert.DeserializeObject<Parent[]>(File.ReadAllText(path+@"\parents.json"));

            while (true)
            {
                Console.WriteLine("Enter Zone:");
                int zone = 1;
                try
                {
                    zone = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.WriteLine("Enter Parent:");
                int parentnumber = 1;
                try
                {
                    parentnumber = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                var parentquery = from parent in parents
                                  where parent.Zone == zone && parent.parentNumber == parentnumber
                                  select parent;
                Console.WriteLine("Press any key to read");
                Console.ReadKey();
                foreach (var p in parentquery)
                {
                    if (zone == 1)
                    {
                        TTLPort.DataReceived -= parents[parentIndex].sensorDataReceivedEventHandler;
                    }
                    else
                    {
                        ZigbeePort.DataReceived -= parents[parentIndex].sensorDataReceivedEventHandler;
                    }
                    parentIndex = Array.IndexOf(parents, p);
                    p.messageDelay = 2000;
                    p.SensorDataReady += ShowSensordata;
                    if (zone==1)
                    {
                        TTLPort.DataReceived += p.sensorDataReceivedEventHandler;
                        p.readSensorData(TTLPort);
                    }
                    else
                    {
                        ZigbeePort.DataReceived += p.sensorDataReceivedEventHandler;
                        p.readSensorData(ZigbeePort);
                    }
                }
                Console.ReadKey();
            }

        }

        private static void ShowSensordata(bool recived)
        {
            buffer = parents[parentIndex].buffer;
            byte[] subbuffer = new byte[6];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Sensor Pack " + (i + 1));
                Console.WriteLine(parents[parentIndex].Sensor[i].GetLatestData().ToString());
                Console.WriteLine("Binary:");
                Array.Copy(buffer, i * 6, subbuffer, 0, 6);
                Console.WriteLine("");
                Console.WriteLine(BitConverter.ToString(subbuffer));
                foreach (var item in subbuffer)
                {
                    Console.WriteLine(Convert.ToString(item, 2).PadLeft(8, '0'));

                }
                Console.WriteLine("");
            }
        }
    }
}
