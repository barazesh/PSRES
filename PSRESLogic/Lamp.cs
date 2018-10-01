using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    public class Lamp
    {
        public byte CurrentIllumination { get; set; }
        public byte Parent { get; set; }
        public byte Zone { get; set; }
        public int Position { get; set; }


        public void Dim(byte dimValue)
        {
            ushort address = Parent << 4;
            string address = Convert.ToString(Zone, 2);

        }
    }
}
