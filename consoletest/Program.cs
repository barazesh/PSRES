using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSRESLogic;


namespace consoletest
{
    class Program
    {
        static void Main(string[] args)
        {
            Lamp[] lamps = new Lamp[5];
            for (int i = 0; i < 5; i++)
            {
                lamps[i]=new Lamp(2);
                lamps[i].PWMpin = i + 1;
            }

            Console.WriteLine("enter lamp number");
            string lampnumber = Console.ReadLine();
            Console.WriteLine("enter dim value");
            string dimvalue = Console.ReadLine();
            byte[] data;
            if (int.TryParse(lampnumber,out int lnumber))
            {
                data=lamps[lnumber].Dim(byte.Parse(dimvalue));
            }
            else
            {
                data = Lamp.DimAll(byte.Parse(dimvalue),2);
            }
            SerialPort mySerialPort1 = new SerialPort(SerialPort.GetPortNames()[1], 115200, Parity.None, 8, StopBits.One);
            mySerialPort1.Open();
            mySerialPort1.Write(data, 0, 2);

            Console.ReadKey();
            mySerialPort1.Close();




        }
    }
}
