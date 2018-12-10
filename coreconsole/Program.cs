﻿using System;
using System.IO.Ports;
using PSRESLogic;


namespace coreconsole
{
    class Program
    {
        static SerialPort SensorsPort = new SerialPort("COM10", 115200, Parity.None, 8, StopBits.One);
        static byte[] buffer = new byte[18];


        static bool datarecived;
        static int parentindex;
        static Parent[] parents = {
                new Parent(1),
                new Parent(2),
                new Parent(3)

            };

        static void Main(string[] args)
        {
            datarecived = false;
            for (int i = 0; i < 3; i++)
            {
                parents[i].SensorDataReady += ShowSensrosData;

            }
            Console.WriteLine("Available Ports");
            foreach (var item in SerialPort.GetPortNames())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Enter Port Name");
            SensorsPort.PortName = Console.ReadLine().ToUpper();
            Console.WriteLine("You Selected "+ SensorsPort.PortName);
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();

            while (true)
            {
                Console.WriteLine("Enter the Parent Number to read Sensor data:");


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
