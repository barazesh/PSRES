using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    class Parent
    {
        public int Id { get; set; }
        public int Zone { get; set; }
        public ICollection<Lamp> LampsUnderCover { get; set; }
        public ICollection<SensoringStation> SensoringStationsUnderCover { get; set; }
        public int Position { get; set; }

        byte[] buffer = new byte[18];


        public void readSensorData()
        {
            SerialPort sp = new SerialPort(SerialPort.GetPortNames()[1], 115200, Parity.None, 8, StopBits.One);
            sp.Open();
            sp.DataReceived += sensorDataReceivedEventHandler;

            byte[] message = { (byte)((Position << 6)+2) };
            sp.Write(message, 0, 1);


        }
        
        private void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            SensorRecording[] sr = new SensorRecording[3];
            
            sp.Read(buffer, 0,buffer.Length);
            for (int i = 0; i < 3; i++)
            {
                sr[i].Illumination = ((buffer[i*6] << 8) | (buffer[(i*6)+1])) / 1.2;

                if (buffer[(i * 6) + 4] >= 128)
                {
                    sr[i].Presence = true;
                    sr[i].Distance = ((buffer[(i * 6) + 4] - 128) << 8) + buffer[(i * 6) + 5];
                }
                else
                {
                    sr[i].Presence = false;
                    sr[i].Distance = (buffer[(i * 6) + 4] << 8) + buffer[(i * 6) + 5];
                }

                /*
                int temp;
                uint8_t j;
                uint8_t data[9];
                int8_t minus = 0, digit;
                double temperature;
                temp = data[2] | (data[3] << 8);

                /* Check if temperature is negative */
                /*if (temp & 0x8000)
                {
                    temp = ~temp + 1;
                    minus = 1;
                }
               
                digit = temp >> 4;
                digit |= ((temp >> 8) & 0x7) << 4;

                temperature = (temp & 0x0F) * 0.0625;


                temperature = digit + temperature;
                if (minus)
                {
                    temperature = 0 - temperature;
                }
                sr[i].Tmeperature = temperature; */

            }
            


        }
    }
}
