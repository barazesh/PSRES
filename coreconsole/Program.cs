using System;
using System.IO;
using System.IO.Ports;
using Newtonsoft.Json;
using PSRESLogic;


namespace coreconsole
{
    class Program
    {
        static SerialPort TTLPort = new SerialPort("COM4", 115200, Parity.None, 8, StopBits.One);
        static SerialPort ZigbeePort = new SerialPort("COM5", 115200, Parity.None, 8, StopBits.One);


        static int l = 0;
        static Lamp[] Lamps = new Lamp[26];

        static void Main(string[] args)
        {

            //initiate the lamps
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Lamps = JsonConvert.DeserializeObject<Lamp[]>(File.ReadAllText(path + @"\Lamps.json"));

            while (true)
            {
                int zone = 1;
                Console.WriteLine("Enter Lamp Number");
                try
                {
                    l = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("please enter an integer between 1 and 26");

                }
                zone = Lamps[l - 1].Zone;
                Console.WriteLine("enter duty cycle:");
                byte duty = 0;
                try
                {
                    duty = byte.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                var message = Lamps[l - 1].Dim(duty);
                byte[] Zmessage =
                        {
                            0xFD, 0x02,
                            0x57, 0x3B,
                            message[0],message[1]
                        };
                switch (zone)
                {
                    case 1:
                        TTLPort.Open();
                        TTLPort.Write(message, 0, 2);
                        TTLPort.Close();
                        break;
                    case 2:
                        ZigbeePort.Open();
                        ZigbeePort.Write(Zmessage, 0, 6);
                        ZigbeePort.Close();
                        break;
                    case 3:
                        Zmessage[2] = 0xB5;
                        Zmessage[3] = 0xCE;
                        ZigbeePort.Open();
                        ZigbeePort.Write(Zmessage, 0, 6);
                        ZigbeePort.Close();
                        break;
                }

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



    }
}
