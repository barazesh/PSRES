using System;
using System.Collections.Generic;
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
        public int Position { get; set; }

        private byte[] buffer = new byte[18];
        private bool datarecieved;


        public void readSensorData()
        {
            datarecieved = false;
            SerialPort sp = new SerialPort(SerialPort.GetPortNames()[2], 115200, Parity.None, 8, StopBits.One);
            sp.Open();
            sp.DataReceived += sensorDataReceivedEventHandler;

            //byte[] message = { (byte)((Position << 6)+2) };
            //sp.Write(message, 0, 1);
            while (!datarecieved) { }

            SensorRecording[] sr = new SensorRecording[3];
            for (int i = 0; i < 3; i++)
            {
                //extracting the illumination value
                sr[i] = new SensorRecording();
                sr[i].Illumination = ((buffer[(i * 6) + 2] << 8) | (buffer[(i * 6) + 3])) / 1.2;


                //extracting the temperature value

                double temperature;
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

                temperature = (temp & 0x0F) * 0.0625;


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
                    sr[i].Distance = ((buffer[(i * 6) + 4] - 128) << 8) + buffer[(i * 6) + 5];
                }
                else
                {
                    sr[i].Presence = false;
                    sr[i].Distance = (buffer[(i * 6) + 4] << 8) + buffer[(i * 6) + 5];
                }
                Console.WriteLine(  sr[i].ToString());

            }

        }
        
        private void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            sp.Read(buffer, 0,buffer.Length);
            datarecieved = true;

            


        }
    }
}
