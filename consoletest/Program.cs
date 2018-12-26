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
        static Parent[] parents = new Parent[7];

        static SerialPort TTLPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
        static SerialPort ZigbeePort = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);

        static int TTLDelay;
        static int ZigbeeDelay;
        static void Main(string[] args)
        {
            //initiate the parents
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            parents=JsonConvert.DeserializeObject<Parent[]>(File.ReadAllText(path+@"\parents.json"));

            foreach (var p in parents)
            {
                p.SensorDataReady += SensorDataReadyEventHandler;
            }

            Console.WriteLine("enter the delay for TTL port messages in milliseconds");
            TTLDelay = int.Parse(Console.ReadLine());

            Console.WriteLine("enter the delay for zigbee port messages in milliseconds");
            ZigbeeDelay = int.Parse(Console.ReadLine());
            TTLPort.DataReceived += parents[0].sensorDataReceivedEventHandler;
            parents[0].messageDelay = 10;
            parents[0].readSensorData(TTLPort);
            Console.ReadKey();

        }

        private static void SensorDataReadyEventHandler(bool recived)
        {
             
            if (parents[parentIndex].Zone == 1)
            {
                TTLPort.DataReceived -= parents[parentIndex].sensorDataReceivedEventHandler;
            }
            else
            {
                ZigbeePort.DataReceived -= parents[parentIndex].sensorDataReceivedEventHandler;
            }

            parentIndex++;
            if (parentIndex==7)
            {
                parentIndex = 0;
            }

            if (parents[parentIndex].Zone == 1)
            {
                TTLPort.DataReceived += parents[parentIndex].sensorDataReceivedEventHandler;
                parents[parentIndex].messageDelay = 10;
                parents[parentIndex].readSensorData(TTLPort);
            }
            else
            {
                ZigbeePort.DataReceived += parents[parentIndex].sensorDataReceivedEventHandler;
                parents[parentIndex].messageDelay = 1000;
                parents[parentIndex].readSensorData(ZigbeePort);
            }
        }

    }
}
