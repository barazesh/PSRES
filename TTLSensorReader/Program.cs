using System;
using System.IO.Ports;
using PSRESLogic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

namespace TTLSensorReader
{
    class Program
    {
        static SerialPort TTLPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);

        static Parent[] parents = new Parent[3];
        static Lamp[] Lamps = new Lamp[26];
        static int l = 0;

        private static int parentIndex;

        static void Main(string[] args)
        {
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = new TTLParent((byte)(i + 1));
                parents[i].SensorDataReady += Program_SensorDataReady;
            }
            Console.WriteLine("Hello World!");

            Console.WriteLine("enter the delay in seconds");
            byte delay = byte.Parse(Console.ReadLine());

            //initiate the lamps
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Lamps = JsonConvert.DeserializeObject<Lamp[]>(File.ReadAllText(path + @"\Lamps.json"));
            foreach (Lamp lamp in Lamps)
            {
                lamp.MaxIllumination = 100;
                lamp.Delay = delay;
                lamp.port = TTLPort;
            }
            AssignLampstoSensors();

            TTLPort.DataReceived += parents[0].sensorDataReceivedEventHandler;
            parents[0].readSensorData(TTLPort);
            while (false)
            {


                Console.WriteLine("enter the lamp number");
                bool wronginput = !int.TryParse(Console.ReadLine(), out l);
                while (wronginput)
                {
                    Console.WriteLine("**WARNING!**Please Enter an integer number");
                    wronginput = !int.TryParse(Console.ReadLine(), out l);
                }
                byte duty = 0;


                Console.WriteLine("enter the light in percents");
                wronginput = !byte.TryParse(Console.ReadLine(), out duty);
                while (wronginput)
                {
                    Console.WriteLine("**WARNING!**Please Enter an integer number");
                    wronginput = !byte.TryParse(Console.ReadLine(), out duty);
                }
                TTLPort.Write(Lamps[l-1].Dim(duty), 0, 2);
            }
            Console.ReadKey();
        }

        private static void AssignLampstoSensors()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            SensorPosition[] sensorposition = JsonConvert.DeserializeObject<SensorPosition[]>(File.ReadAllText(path + @"\SensorPosition.json"));
            foreach (var sensor in sensorposition)
            {
                var lampsquery = from lamp in Lamps where lamp.Position.Contains(sensor.Position) select lamp;
                foreach (var l in lampsquery)
                {
                    parents[sensor.Parent - 1].Sensor[sensor.IDC - 1].PresenceChanged += l.StateChangedHandler;
                }
            }
        }

        private static void Program_SensorDataReady(bool recived)
        {
            TTLPort.DataReceived -= parents[parentIndex].sensorDataReceivedEventHandler;

            parentIndex++;
            if (parentIndex == parents.Length)
            {
                parentIndex = 0;
            }

            TTLPort.DataReceived += parents[parentIndex].sensorDataReceivedEventHandler;
            parents[parentIndex].readSensorData(TTLPort);
        }
    }
}
