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
using PSRESLogic;
using PSRES.Data;

namespace ReadMeter
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort("COM10", 9600, Parity.Even, 7, StopBits.One);
        Meter meter = new Meter();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmboxPorts.Items.AddRange(SerialPort.GetPortNames());

        }

        private void btnOpenPort_Click(object sender, EventArgs e)
        {
            sp.PortName = cmboxPorts.Text;
            sp.Open();
        }

        private void btnReadMeter_Click(object sender, EventArgs e)
        {
            if (sp.IsOpen)
            {

                if (cmboxMeters.Text.Equals("Big Room HVAC"))
                {
                    meter.Serialcode = 18119713646205;
                }
                else
                {
                    meter.Serialcode = 18119713646206;
                }
                MeterRecording mr= meter.Read(sp);
                using (var context=new PSRESContext())
                {
                    context.MeterRecordings.Add(mr);
                    context.SaveChanges();
                }

                decimal[] values =
                {
                    mr.activeEnergy,
                    mr.reactiveEnergy,
                    mr.voltage,
                    mr.current,
                    mr.frequency,
                    mr.activePower,
                    mr.reactivePower,
                    mr.powerFactor,
                };
                populateFrom(values, meter.Serialcode);
            }
            else
            {
                MessageBox.Show("Serial port is not open");
            }


        }
        private void populateFrom(decimal[] values, long serialnumber)
        {


            txtSerial.Text = serialnumber.ToString();

            txtActive.Text = values[0].ToString();
            txtReact.Text =values[1].ToString();
            txtVolt.Text = values[2].ToString();
            txtAmpre.Text = values[3].ToString();
            txtFreq.Text = values[4].ToString();
            txtInstantActive.Text = values[5].ToString();
            txtInstantReact.Text = values[6].ToString();
            txtPF.Text = values[7].ToString();


        }
    }
}
