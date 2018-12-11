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
        static int parentindex;
        static Parent[] parents = {
                new Parent(1),
                new Parent(2),
                new Parent(3)

            };

        static void Main(string[] args)
        {
            SensorsPort.DataReceived += SensorsPort_DataReceived;
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
            SensorsPort.PortName = "COM"+Console.ReadLine();
            Console.WriteLine("You Selected "+ SensorsPort.PortName);
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();

            while (true)
            {
                Console.WriteLine("Enter the Parent Number to read Sensor data:");


                SensorsPort.DataReceived -= parents[parentindex].sensorDataReceivedEventHandler;
                bool isright = int.TryParse(Console.ReadLine(), out parentindex);
                if (isright)
                {
                    parentindex -= 1;
                    SensorsPort.DataReceived += parents[parentindex].sensorDataReceivedEventHandler;
                    parents[parentindex].readSensorData(SensorsPort);
                }
                else
                {
                    Console.WriteLine("Please enter an integer!");
                }
                
                Console.ReadKey();

            }

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
                buffer = parents[parentindex].buffer;
                byte[] subbuffer = new byte[6];

                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Sensor Pack "+(i+1));
                    Console.WriteLine(parents[parentindex].sensorsdata[i].GetLatestData().ToString());
                    Console.WriteLine("Binary:");
                    Array.Copy(buffer, i * 6, subbuffer, 0, 6);
                    Console.WriteLine("");
                    Console.WriteLine(BitConverter.ToString(subbuffer));
                    foreach (var item in subbuffer)
                    {
                        Console.WriteLine(Convert.ToString(item,2).PadLeft(8,'0'));

                    }
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine("No Data Recieved");
            }
        }
    }
}
