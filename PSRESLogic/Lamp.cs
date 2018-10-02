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
        public int Parent { get; set; }
        public byte Zone { get; set; }
        public int Position { get; set; }
        public int PWMpin { get; set; }


        public void Dim(byte dimValue)
        {
            //prepare the date part for the message 
            byte[] data = { 0, dimValue };
            int address = Parent << 6;
            address += (PWMpin << 3);
            data[0] = (byte)address;

        }
    }
}
