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

namespace frequencycontrol
{
    public partial class Form1 : Form
    {
        private string val;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            portscmbox.Items.AddRange(ports);
            
        }

        private void PortOpenBtn_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = portscmbox.Text;
                serialPort1.Parity = Parity.Even;
                serialPort1.BaudRate = 115200;
                serialPort1.StopBits = StopBits.One;
                serialPort1.DataBits = 8;

                serialPort1.Open();
            }
            catch (Exception err)
            {

                MessageBox.Show(err.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void SendBtn_Click(object sender, EventArgs e)
        {
            byte[] val = { 32, 20 };
            byte incr = 20;
            val[0] = byte.Parse(dutycycletxt.Text);
            byte freq = byte.Parse(freqtxt.Text);
            val[1]=freq;
            actualFreqlbl.Text = (freq * incr).ToString();
            serialPort1.Write(val, 0, 2);
        }
    }
}
