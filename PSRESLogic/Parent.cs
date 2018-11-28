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

        private List<double> Temperature1= new List<double>();
        private List<double> Illumination1=new List<double>();
        private List<double> Distance1=new List<double>();
        private bool Presence1;

        private List<double> Temperature2= new List<double>();
        private List<double> Illumination2=new List<double>();
        private List<double> Distance2=new List<double>();
        private bool Presence2;

        private List<double> Temperature3= new List<double>();
        private List<double> Illumination3=new List<double>();
        private List<double> Distance3=new List<double>();
        private bool Presence3;




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

        public SensorData[] GetrealTimeData()
        {
            SensorData[] sd = new SensorData[3];
            sd[0] = new SensorData();
            sd[0].Temperature = Temperature1.LastOrDefault();
            sd[0].Distance = Distance1.LastOrDefault();
            sd[0].Presence = Presence1;
            sd[0].Illumination = Illumination1.LastOrDefault();

            sd[1] = new SensorData();
            sd[1].Temperature = Temperature2.LastOrDefault();
            sd[1].Distance = Distance2.LastOrDefault();
            sd[1].Presence = Presence2;
            sd[1].Illumination = Illumination2.LastOrDefault();

            sd[2] = new SensorData();
            sd[2].Temperature = Temperature3.LastOrDefault();
            sd[2].Distance = Distance3.LastOrDefault();
            sd[2].Presence = Presence3;
            sd[2].Illumination = Illumination3.LastOrDefault();


            return sd;


        }

        private void extractSensorData(byte[] buffer)
        {
            #region Sensor1

            //extracting the illumination value
            Illumination1.Add(((buffer[2] << 8) | (buffer[3])) / 1.2);

            //extracting the temperature value

            int temp = ((buffer[0] << 8) | (buffer[1]));
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
            Temperature1.Add(temperature);

            //extracting the distance and presence

            if (buffer[4] >= 0x80)
            {
                Presence1 = true;
                Distance1.Add((((buffer[4] - 128) << 8) + buffer[5]) * 0.017);
            }
            else
            {
                Presence1 = false;
                Distance1.Add(((buffer[4] << 8) + buffer[5]) * 0.017);
            }
            #endregion

            #region Sensor2

            //extracting the illumination value
            Illumination2.Add(((buffer[8] << 8) | (buffer[9])) / 1.2);

            //extracting the temperature value

            temp = ((buffer[6] << 8) | (buffer[7]));
            minus = false;

            /* Check if temperature is negative */
            if (temp > 0x8000)
            {
                temp = ~temp + 1;
                minus = true;
            }

            digit = temp >> 4;
            digit |= ((temp >> 8) & 0x07) << 4;

            temperature = (temp & 0x0F) * 0.0625;


            temperature = digit + temperature;
            if (minus)
            {
                temperature = 0 - temperature;
            }
            Temperature2.Add(temperature);

            //extracting the distance and presence

            if (buffer[10] >= 0x80)
            {
                Presence2 = true;
                Distance2.Add((((buffer[10] - 128) << 8) + buffer[11]) * 0.017);
            }
            else
            {
                Presence2 = false;
                Distance2.Add(((buffer[10] << 8) + buffer[11]) * 0.017);
            }
            #endregion

            #region Sensor3

            //extracting the illumination value
            Illumination3.Add(((buffer[14] << 8) | (buffer[15])) / 1.2);

            //extracting the temperature value

            temp = ((buffer[12] << 8) | (buffer[13]));
            minus = false;

            /* Check if temperature is negative */
            if (temp > 0x8000)
            {
                temp = ~temp + 1;
                minus = true;
            }

            digit = temp >> 4;
            digit |= ((temp >> 8) & 0x07) << 4;

            temperature = (temp & 0x0F) * 0.0625;


            temperature = digit + temperature;
            if (minus)
            {
                temperature = 0 - temperature;
            }
            Temperature3.Add(temperature);

            //extracting the distance and presence

            if (buffer[16] >= 0x80)
            {
                Presence3 = true;
                Distance3.Add((((buffer[16] - 128) << 8) + buffer[17]) * 0.017);
            }
            else
            {
                Presence3 = false;
                Distance3.Add(((buffer[16] << 8) + buffer[17]) * 0.017);
            }
            #endregion

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
