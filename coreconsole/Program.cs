using System;
using System.IO;
using System.IO.Ports;
using Newtonsoft.Json;
using PSRESLogic;


namespace coreconsole
{
    class Program
    {
        static SerialPort TTLPort = new SerialPort("COM10", 115200, Parity.None, 8, StopBits.One);
        static SerialPort ZigbeePort = new SerialPort("COM11", 115200, Parity.None, 8, StopBits.One);

        static byte[] buffer = new byte[18];


        static bool datarecived;
        static int parentindex=0;
        static Parent[] parents = new Parent[7];
        static Lamp[] Lamps = new Lamp[26];

        static void Main(string[] args)
        {

            //initiate the parents
            parents = JsonConvert.DeserializeObject<Parent[]>(File.ReadAllText(@"~\PSRESLogic\parents.json"));

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i].SensorDataReady += ShowSensrosData;
                parents[i].SensorDataReady += ParentDataready;

            }

            //initiate the sensors



            //initiate the lamps
            Lamps = JsonConvert.DeserializeObject<Lamp[]>(File.ReadAllText(@"~\PSRESLogic\Lamps.json"));
            foreach (Lamp lamp in Lamps)
            {
                foreach (var p in lamp.Position)
                {
                    //select the parent related to this position

                    //subscribe this lamps event handler to the corresponding sensorpack event

                    //parents[i].sensorsdata[j].PresenceChanged += lamp.StateChangedHandler;

                }
            }

            //SensorsPort.DataReceived += SensorsPort_DataReceived;
            datarecived = false;




            Console.WriteLine("Available Ports");
            foreach (var item in SerialPort.GetPortNames())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("Enter Port Name");
            TTLPort.PortName = "COM"+Console.ReadLine();
            Console.WriteLine("You Selected "+ TTLPort.PortName);
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();


            TTLPort.DataReceived += parents[parentindex].sensorDataReceivedEventHandler;
            parents[parentindex].readSensorData(TTLPort);
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
            if (!TTLPort.IsOpen)
            {
                TTLPort.Open();
            }
            TTLPort.Write(Lamps[5].Dim(Dim), 0, 2);
            TTLPort.Close();
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
            if (!TTLPort.IsOpen)
            {
                TTLPort.Open();
            }
            TTLPort.Write(Lamps[4].Dim(Dim), 0, 2);
            TTLPort.Close();
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
            if (!TTLPort.IsOpen)
            {
                TTLPort.Open();
            }
            TTLPort.Write(Lamps[0].Dim(Dim), 0, 2);
            TTLPort.Write(Lamps[1].Dim(Dim), 0, 2);
            TTLPort.Write(Lamps[2].Dim(Dim), 0, 2);
            TTLPort.Close();
        }

        private static void ParentDataready(bool recived)
        {
            TTLPort.DataReceived -= parents[parentindex].sensorDataReceivedEventHandler;
            if (parentindex==parents.Length-1)
            {
                parentindex = 0;
            }
            else
            {
                parentindex++;
            }
            TTLPort.DataReceived += parents[parentindex].sensorDataReceivedEventHandler;
            parents[parentindex].readSensorData(TTLPort);
        }

        private static void SensorsPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            Console.WriteLine(sp.BytesToRead); 
        }

        private static void ShowSensrosData(bool recived)
        {
            Console.WriteLine();
            if (TTLPort.IsOpen)
            {
                TTLPort.Close();
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
