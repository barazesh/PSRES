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
        int lampnumber;
        byte[] data;
        SerialPort sp = new SerialPort(SerialPort.GetPortNames()[1], 115200, Parity.None, 8, StopBits.One);
        public Form1()
        {
            InitializeComponent();
            sp.Open();
        }
        Lamp[] lamps = new Lamp[5];


        private void btndutycycle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                lamps[i] = new Lamp(2);
                lamps[i].PWMpin = i + 1;
            }
            

            if (checkBox1.Checked)
            {
                data = Lamp.DimAll(byte.Parse(txtdutycycle.Text), 2);

            }
            else
            {
                lampnumber = int.Parse(txtlampselector.Text);
                data = lamps[lampnumber].Dim(byte.Parse(txtdutycycle.Text));
            }
            
         
            sp.Write(data, 0, 2);

        }

        private void btnfrequency_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                lamps[i] = new Lamp(2);
                lamps[i].PWMpin = i + 1;
            }
            if (checkBox1.Checked)
            {
                data = Lamp.changeFrequencyAll(byte.Parse(txtfrequency.Text), 2);

            }
            else
            {
                lampnumber = int.Parse(txtlampselector.Text);
                data = lamps[lampnumber].changeFreqency(byte.Parse(txtfrequency.Text));
            }

            sp.Write(data, 0, 2);


        }
    }
}
