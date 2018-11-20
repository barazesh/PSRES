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
        private Parent parent = new Parent(2);
        private bool datarecived;
        SensorRecording[] sr = new SensorRecording[3];

        public Form1()
        {

            InitializeComponent();
            cmboxPorts.Items.AddRange(SerialPort.GetPortNames());
            serialPort1.BaudRate = 115200;
            serialPort1.DataReceived += parent.sensorDataReceivedEventHandler;
            parent.SensorDataReady += populateSensorFrom;

            for (int i = 0; i < 5; i++)
            {
                lamps[i] = new Lamp(2);
                lamps[i].PWMpin = i + 1;
            }
        }



        private void populateSensorFrom(bool r, SensorRecording[] recording)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            datarecived = r;
            sr = recording;
            Invoke(new EventHandler(populate));
            
        }

        private void populate(object sender, EventArgs e)
        {
            if (datarecived)
            {
                txtTemp1.Text = sr[0].Temperature.ToString();
                txtTempbin1.Text = Convert.ToString(((parent.buffer[0] << 8) + parent.buffer[1]), 2);
                txtLight1.Text = sr[0].Illumination.ToString();
                txtLightbin1.Text = Convert.ToString(((parent.buffer[2] << 8) + parent.buffer[3]), 2);
                txtDist1.Text = sr[0].Distance.ToString();
                txtDistbin1.Text = Convert.ToString(((parent.buffer[4] & 0x7F) << 8) + parent.buffer[5], 2);
                txtPresence1.Text = (parent.buffer[4] > 0x80).ToString();

                txtTemp2.Text = sr[1].Temperature.ToString();
                txtTempbin2.Text = Convert.ToString(((parent.buffer[6] << 8) + parent.buffer[7]), 2);
                txtLight2.Text = sr[1].Illumination.ToString();
                txtLightbin2.Text = Convert.ToString(((parent.buffer[8] << 8) + parent.buffer[9]), 2);
                txtDist2.Text = sr[1].Distance.ToString();
                txtDistbin2.Text = Convert.ToString(((parent.buffer[10] & 0x7F) << 8) + parent.buffer[11], 2);
                txtPresence2.Text = (parent.buffer[10] > 0x80).ToString();

                txtTemp3.Text = sr[2].Temperature.ToString();
                txtTempbin3.Text = Convert.ToString(((parent.buffer[12] << 8) + parent.buffer[13]), 2);
                txtLight3.Text = sr[2].Illumination.ToString();
                txtLightbin3.Text = Convert.ToString(((parent.buffer[14] << 8) + parent.buffer[15]), 2);
                txtDist3.Text = sr[2].Distance.ToString();
                txtDistbin3.Text = Convert.ToString(((parent.buffer[16] & 0x7F) << 8) + parent.buffer[17], 2);
                txtPresence3.Text = (parent.buffer[16] > 0x80).ToString();
            }
            else
            {
                MessageBox.Show("No Data Received");
            }
        }

        private void btndutycycle_Click(object sender, EventArgs e)
        {


            if (checkBox1.Checked)
            {
                data = Lamp.DimAll(byte.Parse(txtdutycycle.Text), 2);

            }
            else
            {
                lampnumber = int.Parse(cmboxLamps.Text)-1;
                data = lamps[lampnumber].Dim(byte.Parse(txtdutycycle.Text));
            }
            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
            }
            serialPort1.Write(data, 0, 2);
            serialPort1.Close();
            
         
            

        }

        private void btnfrequency_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                data = Lamp.changeFrequencyAll(byte.Parse(txtfrequency.Text), 2);

            }
            else
            {
                lampnumber = int.Parse(cmboxLamps.Text)-1;
                data = lamps[lampnumber].changeFreqency(byte.Parse(txtfrequency.Text));
            }

            if (!serialPort1.IsOpen)
            {
                serialPort1.Open();
            }
            serialPort1.Write(data, 0, 2);
            serialPort1.Close();




        }



        private void btnReadSensor_Click(object sender, EventArgs e)
        {
            parent.readSensorData(serialPort1);
        }

        private void btnPort_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = cmboxPorts.Text;
        }

        private void btnRefreshPortNames_Click(object sender, EventArgs e)
        {
            cmboxPorts.Items.Clear();
            cmboxPorts.Items.AddRange(SerialPort.GetPortNames());


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                cmboxLamps.Enabled = false;
            }
            else
            {
                cmboxLamps.Enabled = true;

            }
        }
    }
}


