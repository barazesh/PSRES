using Newtonsoft.Json;
using PSRESLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Timers;

namespace consoletest
{
    class Program
    {
        static Timer timer = new Timer(2000);
        static Timer timer2 = new Timer(1800);

        static void Main(string[] args)
        {
            timer.AutoReset = true;
            timer2.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            timer2.Elapsed += Timer2_Elapsed;
            Console.WriteLine("Hi");
            timer.Start();
            timer2.Start();

            Console.ReadKey();

        }

        private static void Timer2_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (timer.Enabled==false)
            {
                Console.WriteLine("starting the first timer fresh");
                timer.Start();
            }
            else
            {
                Console.WriteLine("restarting the first timer");
                timer.Stop();
                timer.Start();
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("specified time elapsed");
        }
    }
}
