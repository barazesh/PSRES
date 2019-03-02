﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PSRESLogic
{
    public class Lamp
    {
        public byte CurrentIllumination { get; set; }
        public byte Parent { get; set; }
        public byte Zone { get; set; }
        public byte[] Position { get; set; }
        public byte PWMpin { get; set; }
        public byte LampId { get; set; }
        public SerialPort port { get; set; }
        public byte MaxIllumination { get; set; }
        public byte MinIllumination { get; set; }
        public byte Delay { get; set; }

        private Timer delaytimer= new Timer();


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

        private void Delaytimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            port.Write(Dim(MinIllumination), 0, 2);
        }

        

        public void ShowUpHandler()
        {
            if (delaytimer.Enabled == false)//timer is not already running
            {
                port.Write(Dim(MaxIllumination), 0, 2);
            }
            else
            {
                port.Write(Dim(MaxIllumination), 0, 2);
                delaytimer.Enabled = false;
                delaytimer.Stop();
            }
        }

        internal void lightUp()
        {
            port.Write(Dim(MaxIllumination), 0, 2);
        }

        internal void lightDown()
        {
            port.Write(Dim(MinIllumination), 0, 2);
        }

        public void LeaveHandler()
        {
            delaytimer.Interval = Delay * 1000;
            delaytimer.Enabled = true;
            delaytimer.Start();
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




        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("ID: ");
            sb.AppendLine(LampId.ToString());

            sb.Append("Position: ");
            foreach (var p in Position)
            {
                sb.Append(p.ToString()+",");
            }
            sb.AppendLine();

            sb.Append("Zone: ");
            sb.AppendLine(Zone.ToString());

            sb.Append("Parent: ");
            sb.AppendLine(Parent.ToString());

            sb.Append("PWM No.: ");
            sb.AppendLine(PWMpin.ToString());

            sb.Append("Current Illumination: ");
            sb.AppendLine(CurrentIllumination.ToString());
            return sb.ToString();

        }

        public Lamp(int parent)
        {
            Parent = (byte)parent;
            delaytimer.AutoReset = false;
            delaytimer.Elapsed += Delaytimer_Elapsed;
        }

        public Lamp(byte parent)
        {
            Parent = parent;
            delaytimer.AutoReset = false;
            delaytimer.Elapsed += Delaytimer_Elapsed;

        }
        public Lamp()
        {
            delaytimer.AutoReset = false;
            delaytimer.Elapsed += Delaytimer_Elapsed;
        }


    }
}
