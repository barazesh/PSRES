using System;
using System.IO.Ports;
using PSRESLogic;


namespace coreconsole
{
    class Program
    {
        static SerialPort SensorsPort = new SerialPort("COM10", 115200, Parity.None, 8, StopBits.One);
        static byte[] buffer = new byte[18];


        static bool datarecived;
        static int parentindex=0;
        static Parent[] parents = {
                new Parent(1),
                new Parent(2),
                new Parent(3)

            };
        static Lamp[] Lamps = new Lamp[13];

        static void Main(string[] args)
        {
            //SensorsPort.DataReceived += SensorsPort_DataReceived;
            datarecived = false;
            for (int i = 0; i < 3; i++)
            {
                parents[i].SensorDataReady += ShowSensrosData;
                parents[i].SensorDataReady += ParentDataready;

            }


            for (int i = 0; i < Lamps.Length; i++)
            {
                Lamps[i] = new Lamp();
            }
            parents[0].sensorsdata[0].PresenceChanged += Drroom;

            Lamps[0].Parent = 1;
            Lamps[0].PWMpin = 1;

            Lamps[1].Parent = 3;
            Lamps[1].PWMpin = 1;

            Lamps[2].Parent = 3;
            Lamps[2].PWMpin = 2;


            parents[0].sensorsdata[2].PresenceChanged += KarAmooz;

            Lamps[4].Parent = 2;
            Lamps[4].PWMpin = 4;


            parents[0].sensorsdata[1].PresenceChanged += Torbatia;

            Lamps[5].Parent = 1;
            Lamps[5].PWMpin = 2;







            Console.WriteLine("Available Ports");
            foreach (var item in SerialPort.GetPortNames())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Enter Port Name");
            SensorsPort.PortName = "COM"+Console.ReadLine();
            Console.WriteLine("You Selected "+ SensorsPort.PortName);
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();


            SensorsPort.DataReceived += parents[parentindex].sensorDataReceivedEventHandler;
            parents[parentindex].readSensorData(SensorsPort);
            while (true)
            {

            }

        }

        private static void Torbatia(bool presence)
        {
            byte Dim;

            if (presence)
            {
                Dim = 100;

            }
            else
            {
                Dim = 0;
            }
            if (!SensorsPort.IsOpen)
            {
                SensorsPort.Open();
            }
            SensorsPort.Write(Lamps[5].Dim(Dim), 0, 2);
            SensorsPort.Close();
        }

        private static void KarAmooz(bool presence)
        {
            byte Dim;

            if (presence)
            {
                Dim = 100;

            }
            else
            {
                Dim = 0;
            }
            if (!SensorsPort.IsOpen)
            {
                SensorsPort.Open();
            }
            SensorsPort.Write(Lamps[4].Dim(Dim), 0, 2);
            SensorsPort.Close();
        }

        private static void Drroom(bool presence)
        {
            byte Dim;

            if (presence)
            {
                Dim = 100;

            }
            else
            {
                Dim = 0;
            }
            if (!SensorsPort.IsOpen)
            {
                SensorsPort.Open();
            }
            SensorsPort.Write(Lamps[0].Dim(Dim), 0, 2);
            SensorsPort.Write(Lamps[1].Dim(Dim), 0, 2);
            SensorsPort.Write(Lamps[2].Dim(Dim), 0, 2);
            SensorsPort.Close();
        }

        private static void ParentDataready(bool recived)
        {
            SensorsPort.DataReceived -= parents[parentindex].sensorDataReceivedEventHandler;
            if (parentindex==parents.Length-1)
            {
                parentindex = 0;
            }
            else
            {
                parentindex++;
            }
            SensorsPort.DataReceived += parents[parentindex].sensorDataReceivedEventHandler;
            parents[parentindex].readSensorData(SensorsPort);
        }

        private static void SensorsPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            Console.WriteLine(sp.BytesToRead); 
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
                //buffer = parents[parentindex].buffer;
                //byte[] subbuffer = new byte[6];

                //for (int i = 0; i < 3; i++)
                //{
                //    Console.WriteLine("Sensor Pack "+(i+1));
                //    Console.WriteLine(parents[parentindex].sensorsdata[i].GetLatestData().ToString());
                //    Console.WriteLine("Binary:");
                //    Array.Copy(buffer, i * 6, subbuffer, 0, 6);
                //    Console.WriteLine("");
                //    Console.WriteLine(BitConverter.ToString(subbuffer));
                //    foreach (var item in subbuffer)
                //    {
                //        Console.WriteLine(Convert.ToString(item,2).PadLeft(8,'0'));

                //    }
                //    Console.WriteLine("");
                //}

            }
            else
            {
                Console.WriteLine("No Data Recieved");
            }
        }
    }
}
