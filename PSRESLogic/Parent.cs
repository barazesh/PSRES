using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    public class Parent
    {
        public int Id { get; set; }
        public int Zone { get; set; }
        public ICollection<Lamp> LampsUnderCover { get; set; }
        public ICollection<SensoringStation> SensoringStationsUnderCover { get; set; }
        public int parentNumber { get; set; }

        public byte[] buffer = new byte[18];
        private bool datarecieved;
        private byte[] readRequestMessage = new byte[2];
        private Stopwatch watch = new Stopwatch();
        private SensorRecording[] sr = new SensorRecording[3];
        


        public SensorRecording[] readSensorData(SerialPort sp)
        {
            
            datarecieved = false;

            sp.Open();

            sp.Write(readRequestMessage, 0, 2);
            watch.Restart();

            while (!datarecieved) {}
            return sr;
            
        }

        

        private void extractSensorData(byte[] buffer)
        {

            for (int i = 0; i < 3; i++)
            {
                //extracting the illumination value
                sr[i] = new SensorRecording();
                sr[i].Illumination = ((buffer[(i * 6) + 2] << 8) | (buffer[(i * 6) + 3])) / 1.2;


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
                sr[i].Temperature = temperature;

                //extracting the distance and presence

                if (buffer[(i * 6) + 4] >= 0x80)
                {
                    sr[i].Presence = true;
                    sr[i].Distance = (((buffer[(i * 6) + 4] - 128) << 8) + buffer[(i * 6) + 5]) * 0.017;
                }
                else
                {
                    sr[i].Presence = false;
                    sr[i].Distance = ((buffer[(i * 6) + 4] << 8) + buffer[(i * 6) + 5]) * 0.017;
                }
                //Console.WriteLine(sr[i].ToString());

            }

        }

        public void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            
            long a = watch.ElapsedMilliseconds;
            SerialPort sp = (SerialPort)sender;
            
            sp.Read(buffer, 0,buffer.Length);
            sp.Close();
            extractSensorData(buffer);

            datarecieved = true;

        }


        public Parent(int parentnumber)
        {
            parentNumber = parentnumber;
            readRequestMessage[0] = (byte)((parentNumber << 6) + 56);
            readRequestMessage[1] = (byte)~readRequestMessage[0];

        }
    }
}
