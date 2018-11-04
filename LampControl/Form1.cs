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
        private int lampnumber;
        private byte[] data;
        private byte[] buffer = new byte[18];
        private Lamp[] lamps = new Lamp[5];
        private Parent parent = new Parent();
        private SensorRecording[] sr = new SensorRecording[3];

        public Form1()
        {
            InitializeComponent();
            serialPort1.PortName = SerialPort.GetPortNames()[2];
            serialPort1.BaudRate = 115200;
            serialPort1.DataReceived += sensorDataReceivedEventHandler;
            serialPort1.Open();
        }

        private void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            sp.Read(buffer, 0, buffer.Length);
            sr=parent.extractSensorData(buffer);
            Invoke(new EventHandler(populate));


        }

        private void populate(object sender, EventArgs e)
        {
            txtTemp1.Text = sr[0].Temperature.ToString();
            txtTempbin1.Text = Convert.ToString(((buffer[0] << 8) + buffer[1]), 2);
            txtLight1.Text = sr[0].Illumination.ToString();
            txtLightbin1.Text = Convert.ToString(((buffer[2] << 8) + buffer[3]), 2);
            txtDist1.Text = sr[0].Distance.ToString();
            txtDistbin1.Text = Convert.ToString(((buffer[4] & 0x7F) << 8) + buffer[5], 2);
            txtPresence1.Text = (buffer[4] > 0x80).ToString();

            txtTemp2.Text = sr[1].Temperature.ToString();
            txtTempbin2.Text = Convert.ToString(((buffer[6] << 8) + buffer[7]), 2);
            txtLight2.Text = sr[1].Illumination.ToString();
            txtLightbin2.Text = Convert.ToString(((buffer[8] << 8) + buffer[9]), 2);
            txtDist2.Text = sr[1].Distance.ToString();
            txtDistbin2.Text = Convert.ToString(((buffer[10] & 0x7F) << 8) + buffer[11], 2);
            txtPresence2.Text = (buffer[10] > 0x80).ToString();

            txtTemp3.Text = sr[2].Temperature.ToString();
            txtTempbin3.Text = Convert.ToString(((buffer[12] << 8) + buffer[13]), 2);
            txtLight3.Text = sr[2].Illumination.ToString();
            txtLightbin3.Text = Convert.ToString(((buffer[14] << 8) + buffer[15]), 2);
            txtDist3.Text = sr[2].Distance.ToString();
            txtDistbin3.Text = Convert.ToString(((buffer[16] & 0x7F) << 8) + buffer[17], 2);
            txtPresence3.Text = (buffer[16] > 0x80).ToString();
        }

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
            
         
            serialPort1.Write(data, 0, 2);

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

            serialPort1.Write(data, 0, 2);


        }



        private void populateSensorForm(SensorRecording[] sr, byte[] inByte)
        {
            txtTemp1.Text = sr[0].Temperature.ToString();
            txtTempbin1.Text = Convert.ToString(((inByte[0] << 8) + inByte[1]),2);
            txtLight1.Text = sr[0].Illumination.ToString();
            txtLightbin1.Text= Convert.ToString(((inByte[2] << 8) + inByte[3]), 2);
            txtDist1.Text = sr[0].Distance.ToString();
            txtDistbin1.Text = Convert.ToString(((inByte[4] & 0x7F) << 8) + inByte[5],2);
            txtPresence1.Text = (inByte[4] > 0x80).ToString();

        }

    }
}
