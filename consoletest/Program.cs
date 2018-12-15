using Newtonsoft.Json;
using PSRESLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace consoletest
{
    class Program
    {
        static void Main(string[] args)
        {
            Lamp[] lamp = new Lamp[26];
            Stopwatch watch = new Stopwatch();
            watch.Start();
            lamp = JsonConvert.DeserializeObject<Lamp[]>(File.ReadAllText(@"C:\Users\SM\Source\Repos\PSRES\PSRESLogic\Lamps.json"));
            Console.WriteLine(watch.ElapsedMilliseconds);
            foreach (var l in lamp)
            {
                Console.WriteLine(l.ToString()); 
                Console.WriteLine();
            }
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadKey();
            
        }
    }
}
