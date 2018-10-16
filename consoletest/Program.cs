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
            
            Meter meter1 = new Meter("18119713646209");
            meter1.Read();
            Console.ReadKey();


        }
    }
}
