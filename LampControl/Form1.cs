using PSRESLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace LampControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Lamp[] lamps = new Lamp[5];


        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                lamps[i] = new Lamp(2);
                lamps[i].PWMpin = i + 1;
            }

            int lampnumber;
            byte[] data;
            if (int.TryParse(textBox2.Text,out lampnumber))
            {
                data = lamps[lampnumber].Dim(byte.Parse(textBox1.Text));
            }
            else
            {
                data = Lamp.DimAll(byte.Parse(textBox1.Text), 2);
            }


            SerialPort mySerialPort1 = new SerialPort(SerialPort.GetPortNames()[1], 115200, Parity.None, 8, StopBits.One);
            mySerialPort1.Open();
            mySerialPort1.Write(data, 0, 2);
        }
           


    }
}
