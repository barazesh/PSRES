using System;
using System.IO.Ports;
using PSRESLogic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Text;

namespace TTLSensorReader
{
    class Program
    {
        static SerialPort TTLPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);

        static Parent[] parents = new Parent[3];
        static Lamp[] Lamps = new Lamp[26];
        static int l = 0;

        private static int parentIndex;
        private static bool write2File= false;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Console.WriteLine("enter the delay for lamps in seconds");
            byte lampdelay = byte.Parse(Console.ReadLine());


            Console.WriteLine("enter the maximum illumination for lamps in percents");
            byte maxillumination = byte.Parse(Console.ReadLine());

            Console.WriteLine("enter the minimum illumination for lamps in percents");
            byte minillumination = byte.Parse(Console.ReadLine());

            Console.WriteLine("enter the delay for reading sensors in milliseconds");
            int sensordelay = int.Parse(Console.ReadLine());

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = new TTLParent((byte)(i + 1), sensordelay);
                parents[i].SensorDataReady += Program_SensorDataReady;
            }

            Console.WriteLine("Do you want to write sensor data to file:");
            Console.WriteLine("Y for yes        Anything else for No");
            string inputtext = Console.ReadLine().ToLower();
            if (inputtext=="y")
            {
                write2File = true;
            }


            //initiate the lamps
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Lamps = JsonConvert.DeserializeObject<Lamp[]>(File.ReadAllText(path + @"\Lamps.json"));
            foreach (Lamp lamp in Lamps)
            {
                lamp.MaxIllumination = maxillumination;
                lamp.MinIllumination = minillumination;
                lamp.Delay = lampdelay;
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
                    parents[sensor.Parent - 1].Sensor[sensor.IDC - 1].RelatedLamps.Add(l);
                    //parents[sensor.Parent - 1].Sensor[sensor.IDC - 1].ShowUp += l.ShowUpHandler;
                    //parents[sensor.Parent - 1].Sensor[sensor.IDC - 1].Leave += l.LeaveHandler;

                }
            }
        }

        private static void Program_SensorDataReady()
        {
            if (write2File)
            {
                for (int i = 0; i < 3; i++)
                {
                    logsensordata(parents[parentIndex].Sensor[i],10*(parentIndex+1)+i+1);
                }
            }
            TTLPort.DataReceived -= parents[parentIndex].sensorDataReceivedEventHandler;

            parentIndex++;
            if (parentIndex == parents.Length)
            {
                parentIndex = 0;
            }

            TTLPort.DataReceived += parents[parentIndex].sensorDataReceivedEventHandler;
            parents[parentIndex].readSensorData(TTLPort);
        }

        private static void logsensordata(SensorPack sensorPack, int position)
        {
            StringBuilder sb = new StringBuilder(4);
            InstantSensorData data = sensorPack.GetLatestReading();
            sb.Append(DateTime.Now.Hour.ToString()+",");
            sb.Append(DateTime.Now.Minute.ToString() + ",");
            sb.Append(DateTime.Now.Second.ToString() + ",");
            sb.Append(DateTime.Now.Millisecond.ToString() + ",");
            sb.Append(position.ToString() + ",");
            sb.Append(data.Temperature.ToString() + ",");
            sb.Append(data.Illumination.ToString() + ",");
            sb.Append(data.Distance.ToString() + ",");
            sb.AppendLine(data.Presence.ToString());

            File.AppendAllText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Sensordata.csv", sb.ToString());
        }
    }
}
