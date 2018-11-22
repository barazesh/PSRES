using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PSRESLogic
{
    public delegate void SensorDataReadyHandler(bool recived);

    public class Parent
    {
        public int Id { get; set; }
        public int Zone { get; set; }
        public int parentNumber { get; set; }

        private List<double> Temperature;
        private List<double> Illumination;
        private List<double> Distance;
        private bool Presence;




        public byte[] buffer = new byte[18];
        private bool datarecieved;
        private byte[] readRequestMessage = new byte[2];
        private Stopwatch watch = new Stopwatch();
        private Timer timer = new Timer(100);
        public event SensorDataReadyHandler SensorDataReady;
        


        public void readSensorData(SerialPort sp)
        {
            
            datarecieved = false;

            sp.Open();

            sp.Write(readRequestMessage, 0, 2);
            timer.Start();
        }

        private void timerelapsed(object sender, ElapsedEventArgs e)
        {
            if (datarecieved)
            {
                extractSensorData(buffer);
            }

            onDataReady(datarecieved);


        }



        private void extractSensorData(byte[] buffer)
        {

            for (int i = 0; i < 3; i++)
            {
                //extracting the illumination value
                Illumination.Add(((buffer[(i * 6) + 2] << 8) | (buffer[(i * 6) + 3])) / 1.2);


                //extracting the temperature value

                int temp = ((buffer[(i * 6)] << 8) | (buffer[(i * 6) + 1]));
                bool minus = false;

                /* Check if temperature is negative */
                if (temp > 0x8000)
                {
                    temp = ~temp + 1;
                    minus = true;
                }

                int digit = temp >> 4;
                digit |= ((temp >> 8) & 0x07) << 4;

                double temperature = (temp & 0x0F) * 0.0625;


                temperature = digit + temperature;
                if (minus)
                {
                    temperature = 0 - temperature;
                }
                Temperature.Add(temperature);

                //extracting the distance and presence

                if (buffer[(i * 6) + 4] >= 0x80)
                {
                    Presence = true;
                    Distance.Add((((buffer[(i * 6) + 4] - 128) << 8) + buffer[(i * 6) + 5]) * 0.017);
                }
                else
                {
                    Presence = false;
                    Distance.Add(((buffer[(i * 6) + 4] << 8) + buffer[(i * 6) + 5]) * 0.017);
                }

            }

        }

        public void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            
            long a = watch.ElapsedMilliseconds;
            SerialPort sp = (SerialPort)sender;
            
            sp.Read(buffer, 0,buffer.Length);
            sp.Close();

            datarecieved = true;

        }

        protected virtual void onDataReady(bool recived)
        {
            (SensorDataReady as SensorDataReadyHandler)?.Invoke(recived);
        }

        public Parent(int parentnumber)
        {
            parentNumber = parentnumber;
            readRequestMessage[0] = (byte)((parentNumber << 6) + 56);
            readRequestMessage[1] = (byte)~readRequestMessage[0];

            timer.Elapsed += timerelapsed;
            timer.AutoReset = false;

        }
    }
}
