using System;
using System.Windows.Forms;
using System.IO.Ports;
using PSRESLogic;

namespace ReadMeter
{
    public partial class Form1 : Form
    {
        private Meter[] Meters = new Meter[5];

        private decimal[] meterdata = new decimal[8];
        public Form1()
        {
            InitializeComponent();
        }
        private string[] meternames =
        {
            "Mainroom HVAC",
            "Mainroom Other",
            "Smallroom HVAC",
            "Smallroom Other",
            "Lighting"
        };
        private int selectedindex;

 

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.Even;
            serialPort1.DataBits = 7;
            serialPort1.StopBits = StopBits.One;
            cmboxPorts.Items.AddRange(SerialPort.GetPortNames());


            //instantiate the meters
            for (int i = 0; i < 5; i++)
            {
                Meters[i] = new Meter();
                Meters[i].MeterDataReady += MeterDataHandler;
                Meters[i].Id = i + 1;
            }

            Meters[0].SerialCode = 18119713646205;
            Meters[1].SerialCode = 18119713646206;
            Meters[2].SerialCode = 18119713646207;
            Meters[3].SerialCode = 18119713646209;
            Meters[4].SerialCode = 18119713646208;

            serialPort1.DataReceived += Meters[0].DataReceivedHandler;

            //populate the meter selection textbox

            cmboxMeters.Items.AddRange(meternames);
        }


        private void MeterDataHandler(int meterId)
        {
            meterdata=Meters[meterId - 1].GetRealTimeData();

            Invoke(new EventHandler(populate));

        }

        

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = cmboxPorts.Text;
            serialPort1.Open();
        }

        private void btnReadMeter_Click(object sender, EventArgs e)
        {

            if (serialPort1.IsOpen)
            {
                serialPort1.DataReceived -= Meters[selectedindex].DataReceivedHandler;
                selectedindex = cmboxMeters.SelectedIndex;

                serialPort1.DataReceived += Meters[selectedindex].DataReceivedHandler;
                Meters[selectedindex].Read(serialPort1);
            }
            else
            {
                MessageBox.Show("Serial port is not open");
            }

        }


        private void populate(object sender, EventArgs e)
        {
                txtSerial.Text = Meters[selectedindex].SerialCode.ToString();
                txtActive.Text = meterdata[0].ToString();
                txtReact.Text = meterdata[1].ToString();
                txtVolt.Text = meterdata[4].ToString();
                txtAmpre.Text = meterdata[2].ToString();
                txtFreq.Text = meterdata[3].ToString();
                txtInstantActive.Text = meterdata[6].ToString();
                txtInstantReact.Text = meterdata[7].ToString();
                txtPF.Text = meterdata[5].ToString();
        }

    }
}
