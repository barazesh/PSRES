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
            byte[] val = {32, 20};
            SerialPort newport = new SerialPort
            {
                PortName = "COM6",
                BaudRate = 115200,
                Parity = Parity.Even,
                StopBits = StopBits.One,
                DataBits = 8
            };
            newport.Open();
            bool success = false;
            bool success1 = false;
            byte light;
            byte freq;
            do
            {
                Console.WriteLine("Please duty cycle (an integer value between 0 to 100)");
                success1 = byte.TryParse(Console.ReadLine(), out light);
                Console.WriteLine("please enter frequency");
                success = byte.TryParse(Console.ReadLine(), out freq);
                //Console.WriteLine(Convert.ToString(light,2));
                val[0] = light;
                val[1] = freq;
                newport.Write(val, 0, 2);

            } while (success&success1);
            
        }
    }
}
