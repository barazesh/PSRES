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

namespace ReadMeter
{
    public partial class Form1 : Form
    {
        SerialPort sp = new SerialPort("COM10", 9600, Parity.Even, 7, StopBits.One);
        Meter[] meter =
        {
            new Meter("Main Room HVAC",18119713646205),
            new Meter("Main Room PCs",18119713646206)
        };
        

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
                Meter meter1;

                if (cmboxMeters.Text.Equals("Big Room HVAC"))
                {
                    meter1 = meter[0];
                }
                else
                {
                    meter1 = meter[1];
                }
                meter1.Read(sp);

                decimal[] values =
                {
                    meter1.activeEnergy,
                    meter1.reactiveEnergy,
                    meter1.instantVoltage,
                    meter1.instantCurrent,
                    meter1.instantFrequency,
                    meter1.instantPower,
                    meter1.instantReactivePower,
                    meter1.instantPowerFactor,
                };
                populateFrom(values, meter1.serialnumber, meter1.voltageCuttBegining, meter1.voltageReturn);
            }
            else
            {
                MessageBox.Show("Serial port is not open");
            }


        }
        private void populateFrom(decimal[] values, long serialnumber,string begin,string end)
        {
            txtBegin.Text = begin;
            txtEnd.Text = end;

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
