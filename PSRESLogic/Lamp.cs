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


        public byte[] Dim(byte dimValue)
        {
            //prepare the date part for the message that is going to be sent. the data part consists of two bytes. the first byte is the address of the receiving end and the second byte is the actual message.

            byte[] data = { 0, dimValue };// the second byte is the argument being passed to the method which is the duty cycle of the PWM, controlling the illuminance of the lamp.

            // the first byte which is the address consists of two parts: the most significant two bits indicate the parent code responsible for the lamp. the next three significant bits represent the PWM pin code responsible for the lamp
            int address = Parent << 6;
            address += (PWMpin << 3);
            data[0] = (byte)address;
            return data;

        }

        public static byte[] DimAll(byte dimValue, int parent)
        {
            byte[] data = { 0, dimValue };
            int address = parent << 6;
            data[0] = (byte)address;
            return data;
        }

        public byte[] changeFreqency(byte frequency)
        {
            byte[] data = { 0, frequency };
            int address = Parent << 6;
            address += (PWMpin << 3);
            address += 4;
            data[0] = (byte)address;
            return data;
        }

        public static byte[] changeFrequencyAll(byte frequency, int parent)
        {
            byte[] data = { 0, frequency };
            int address = parent << 6;
            address += 4;
            data[0] = (byte)address;
            return data;
        }


        public Lamp(int parent)
        {
            Parent = parent;
        }

        public Lamp()
        {

        }
    }
}
