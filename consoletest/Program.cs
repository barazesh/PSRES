using System;
using System.Collections.Generic;
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
            Console.WriteLine("enter the parent value");
            int parent = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(parent,2));
            Console.WriteLine("enter pwm pin");
            int pwmpin = int.Parse(Console.ReadLine());
            Console.WriteLine(Convert.ToString(pwmpin, 2));
            int shiftedParent = parent << 6;
            int shiftedPWM = pwmpin << 3;
            Console.Write(shiftedParent);
            Console.Write(" ");
            Console.WriteLine(Convert.ToString(shiftedParent, 2));

            Console.Write(shiftedPWM);
            Console.Write(" ");
            Console.WriteLine(Convert.ToString(shiftedPWM, 2));

            Console.Write(shiftedParent+shiftedPWM);
            Console.Write(" ");
            Console.WriteLine(Convert.ToString(shiftedParent+shiftedPWM, 2));
            Console.ReadKey();
            Lamp newlamp = new Lamp();
            newlamp.Dim(10);
            

        }
    }
}
