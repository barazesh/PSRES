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
        private Lamp[] lamps = new Lamp[6];
        private Parent[] parents =
        {
            new Parent(1),
            new Parent(2),
            new Parent(3)
        };
        private bool datarecived;
        private InstantSensorData[] sd = new InstantSensorData[3];
        private int parentindex;

        public Form1()
        {

            InitializeComponent();
            cmboxPorts.Items.AddRange(SerialPort.GetPortNames());
            serialPort1.BaudRate = 115200;
            //serialPort1.DataReceived += bitcounter;
            for (int i = 0; i < parents.Length; i++)
            {
                parents[i].SensorDataReady += populatesensorform;

            }
            
            for (int i = 0; i < lamps.Length; i++)
            {
                lamps[i] = new Lamp();
                lamps[i].PWMpin = i + 1;
            }
        }

        private void bitcounter(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            MessageBox.Show(sp.BytesToRead.ToString());
        }

        private void populatesensorform(bool recived)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            datarecived = recived;
            if (recived)
            {
                for (int i = 0; i < 3; i++)
                {
                    sd[i] = parents[parentindex].Sensor[i].GetLatestData();
                }

                Invoke(new EventHandler(populate));
            }
            
        }


        private void populate(object sender, EventArgs e)
        {
            if (datarecived)
            {
                txtTemp1.Text = sd[0].Temperature.ToString();
                txtTempbin1.Text = Convert.ToString(((parents[parentindex].buffer[0] << 8) + parents[parentindex].buffer[1]), 2).PadLeft(16, '0');
                txtLight1.Text = sd[0].Illumination.ToString();
                txtLightbin1.Text = Convert.ToString(((parents[parentindex].buffer[2] << 8) + parents[parentindex].buffer[3]), 2).PadLeft(16, '0');
                txtDist1.Text = sd[0].Distance.ToString();
                txtDistbin1.Text = Convert.ToString(((parents[parentindex].buffer[4]) << 8) + parents[parentindex].buffer[5], 2).PadLeft(16, '0');
                txtPresence1.Text = sd[0].Presence.ToString();

                txtTemp2.Text = sd[1].Temperature.ToString();
                txtTempbin2.Text = Convert.ToString(((parents[parentindex].buffer[6] << 8) + parents[parentindex].buffer[7]), 2).PadLeft(16, '0');
                txtLight2.Text = sd[1].Illumination.ToString();
                txtLightbin2.Text = Convert.ToString(((parents[parentindex].buffer[8] << 8) + parents[parentindex].buffer[9]), 2).PadLeft(16, '0');
                txtDist2.Text = sd[1].Distance.ToString();
                txtDistbin2.Text = Convert.ToString(((parents[parentindex].buffer[10]) << 8) + parents[parentindex].buffer[11], 2).PadLeft(16, '0');
                txtPresence2.Text = sd[1].Presence.ToString();

                txtTemp3.Text = sd[2].Temperature.ToString();
                txtTempbin3.Text = Convert.ToString(((parents[parentindex].buffer[12] << 8) + parents[parentindex].buffer[13]), 2).PadLeft(16, '0');
                txtLight3.Text = sd[2].Illumination.ToString();
                txtLightbin3.Text = Convert.ToString(((parents[parentindex].buffer[14] << 8) + parents[parentindex].buffer[15]), 2).PadLeft(16, '0');
                txtDist3.Text = sd[2].Distance.ToString();
                txtDistbin3.Text = Convert.ToString(((parents[parentindex].buffer[16]) << 8) + parents[parentindex].buffer[17], 2).PadLeft(16,'0');
                txtPresence3.Text = sd[2].Presence.ToString();
            }
            else
            {
                MessageBox.Show("No Data Received");
            }
        }

        private void btndutycycle_Click(object sender, EventArgs e)
        {

            parentindex = cmboxParent.SelectedIndex;
            if (chkalllamps.Checked)
            {
                data = Lamp.DimAll(byte.Parse(txtdutycycle.Text), parentindex+1);
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

            if (chkallParents.Checked)
            {
                data[0] &= 0x3F;
            }
            serialPort1.Write(data, 0, 2);
            serialPort1.Close();
        }

        private void btnfrequency_Click(object sender, EventArgs e)
        {
            parentindex = cmboxParent.SelectedIndex;

            if (chkalllamps.Checked)
            {
                data = Lamp.changeFrequencyAll(byte.Parse(txtfrequency.Text), parentindex + 1);

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

            if (chkallParents.Checked)
            {
                data[0] &= 0x3F;
            }
            serialPort1.Write(data, 0, 2);
            serialPort1.Close();
        }



        private void btnReadSensor_Click(object sender, EventArgs e)
        {
            serialPort1.DataReceived -= parents[parentindex].sensorDataReceivedEventHandler;
            parentindex = cmboxParent.SelectedIndex;
            serialPort1.DataReceived += parents[parentindex].sensorDataReceivedEventHandler;

            parents[parentindex].readSensorData(serialPort1);
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
            if (chkalllamps.Checked)
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


