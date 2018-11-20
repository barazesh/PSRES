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
        MeterRecording mr = new MeterRecording();
        private bool dataok;
        private int id;
        public Form1()
        {
            InitializeComponent();
        }

        private void MeterDataReadyEventHandler(bool recived, MeterRecording data)
        {
            dataok = recived;
            mr = data;
            Invoke(new EventHandler(populate));
            
        }

        private void populate(object sender, EventArgs e)
        {

            if (dataok)
            {
                using (var context = new PSRESContext())
                {
                    var meters = context.Meters.ToList();
                    var lasttimedate = context.Dates.Last().Id;
                    mr.MeterId = id;
                    mr.TimeDateId = lasttimedate;
                    context.MeterRecordings.Add(mr);
                    context.SaveChanges();
                }


                txtSerial.Text = meter.Serialcode.ToString();
                txtActive.Text = mr.activeEnergy.ToString();
                txtReact.Text = mr.reactiveEnergy.ToString();
                txtVolt.Text = mr.voltage.ToString();
                txtAmpre.Text = mr.current.ToString();
                txtFreq.Text = mr.frequency.ToString();
                txtInstantActive.Text = mr.activePower.ToString();
                txtInstantReact.Text = mr.reactivePower.ToString();
                txtPF.Text = mr.powerFactor.ToString(); 
            }
            else
            {
                MessageBox.Show("No Data Received");
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmboxPorts.Items.AddRange(SerialPort.GetPortNames());
            meter.MeterDataReady += MeterDataReadyEventHandler;
            sp.DataReceived += meter.DataReceivedHandler;
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
                    id  = 2;
                }
                else
                {
                    meter.Serialcode = 18119713646206;
                    id = 3;
                }
                meter.Read(sp);
            }
            else
            {
                MessageBox.Show("Serial port is not open");
            }

        }

    }
}
