using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace pwmtest1
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[] val = {0b0010_1111, 0b0101_0101, 32 };
            SerialPort newport = new SerialPort
            {
                PortName = "COM5",
                BaudRate = 115200,
                Parity = Parity.Even,
                StopBits = StopBits.One,
                DataBits = 8
            };
            newport.Open();
            bool success = false;
            byte light;
            do
            {
                Console.WriteLine("Please insert an integer value between 0 to 100");
                success = byte.TryParse(Console.ReadLine(), out light);
                Console.WriteLine(Convert.ToString(light,2));
                val[2] = light;
                newport.Write(val, 0, 3);

            } while (success);
            
        }
    }
}
