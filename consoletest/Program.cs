using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PSRES.Data;
using PSRESLogic;


namespace consoletest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("enter meter serial number last 2 digits");
            //long serial = 18119713646200 + int.Parse(Console.ReadLine());
            //Console.WriteLine("enter meter Name");
            //string name = Console.ReadLine();
            //Meter meter = new Meter();
            //meter.Name = name;
            //meter.Serialcode = serial;

            //using (var context = new PSRESContext())
            //{
            //    context.Meters.Add(meter);
            //    context.SaveChanges();
            //}
            //Console.WriteLine("added to database");
            //Console.WriteLine("enter port number");
            //string port = "COM" + Console.ReadLine();
            ////instantiate a port for communication with the meter.
            //SerialPort sp = new SerialPort(port, 9600, Parity.Even, 7, StopBits.One);
            //sp.Open();
            //meter.Read(sp);
            //Console.ReadKey();

            Parent p = new Parent();
            p.readSensorData();
            Console.ReadKey();




        }
    }
}
