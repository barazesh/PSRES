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
using PSRESData;
using System.Timers;
using PSRESData.Entities;

namespace ReadMeter
{
    public partial class Form1 : Form
    {
        private Meter[] Meters = new Meter[2];
        private System.Timers.Timer timer = new System.Timers.Timer(60000);

        private decimal[] meterdata = new decimal[8];
        private int ID;
        public Form1()
        {
            InitializeComponent();
        }

 

        private void Form1_Load(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;
            serialPort1.Parity = Parity.Even;
            serialPort1.DataBits = 7;
            serialPort1.StopBits = StopBits.One;
            cmboxPorts.Items.AddRange(SerialPort.GetPortNames());

            timer.Elapsed += oneMinuteMark;

            //instantiate the meters

            using (var context = new PSRESContext())
            {
                DataBaseSeeder seeder = new DataBaseSeeder(context);
                seeder.Seed();
                var meters = context.Meters.ToArray();
                for (int i = 0; i < Meters.Length; i++)
                {
                    Meters[i] = new Meter();
                    Meters[i].Id = meters[i].Id;
                    Meters[i].SerialCode = meters[i].Serialcode;
                    Meters[i].MeterDataReady += MeterDataHandler;
                    serialPort1.DataReceived += Meters[i].DataReceivedHandler;
                }

            }
        }

        private void MeterDataHandler(int meterId)
        {
            meterdata=Meters[meterId - 1].GetRealTimeData();
            //this handler calls the next meter to read data
            int i=0;
            if (meterId != Meters.Length)
            {
                i = meterId;
            }
            ID = meterId;
            Meters[i].Read(serialPort1);
            Invoke(new EventHandler(populate));

        }

        private void oneMinuteMark(object sender, ElapsedEventArgs e)
        {
            //add data to database

            using (var context = new PSRESContext())
            {

                // add a new entry to timedate table 
                var newtime = new TimeDateEntity()
                {
                    year = DateTime.Now.Year,
                    month = (byte)DateTime.Now.Month,
                    day = (byte)DateTime.Now.Day,
                    hour = (byte)DateTime.Now.Hour,
                    minute = (byte)DateTime.Now.Minute
                };
                context.Dates.Add(newtime);


                // add sensor recordings


                //add meter recordings
                foreach (var m in Meters)
                {
                    MeterRecordingEntity meterdata = m.GetDataForDataBase();
                    meterdata.TimeDateId = newtime.Id;
                    context.MeterRecordings.Add(meterdata);

                    m.Reset();
                }

                //save changes
                context.SaveChanges();
            }

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

                Meters[0].Read(serialPort1);
            }
            else
            {
                MessageBox.Show("Serial port is not open");
            }

        }

        private void MeterDataReadyEventHandler(int meterId)
        {


        }

        private void populate(object sender, EventArgs e)
        {
                txtSerial.Text = Meters[ID].SerialCode.ToString();
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
