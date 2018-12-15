using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Timers;

namespace PSRESLogic
{
    public delegate void SensorDataReadyHandler(bool recived);

    public class Parent
    {
        public int Id { get; set; }
        public int Zone { get; set; }
        public int parentNumber { get; set; }

        public SensorPack[] Sensor = new SensorPack[3];


        public byte[] buffer = new byte[18];
        private bool datarecieved;
        private byte[] readRequestMessage = new byte[2];
        private Stopwatch watch = new Stopwatch();
        private Timer timer = new Timer(50);
        public event SensorDataReadyHandler SensorDataReady;
        

        public void readSensorData(SerialPort sp)
        {
            
            datarecieved = false;
            if (!sp.IsOpen)
            {
                sp.Open();
            }
            if (Zone == 1)
            {
                sp.Write(readRequestMessage, 0, 2);
            }
            else
            {
                byte[] zigbeereadRequextMessage = {
                    0xFD, 0x02,
                    0x57, 0x3b,
                    readRequestMessage[0],readRequestMessage[1]
                    };
                switch (Zone)
                {
                    case 2:
                        sp.Write(zigbeereadRequextMessage, 0, 6);
                        break;
                    case 3:
                        zigbeereadRequextMessage[2] = 0xB5;
                        zigbeereadRequextMessage[3] = 0xCE;

                        sp.Write(zigbeereadRequextMessage, 0, 6);
                        break;
                }
            }

            timer.Start();
        }

        private void timerelapsed(object sender, ElapsedEventArgs e)
        {
            if (datarecieved)
            {
                byte[] subbuffer = new byte[6];
                for (int i = 0; i < 3; i++)
                {
                    Array.Copy(buffer, i * 6, subbuffer, 0, 6);
                    Sensor[i].Update(subbuffer);
                }
            }
            onDataReady(datarecieved);

        }


        public void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] readbuffer = new byte[22];
            long a = watch.ElapsedMilliseconds;
            SerialPort sp = (SerialPort)sender;

            if (Zone ==1)
            {
                sp.Read(buffer, 0, 18);
            }
            else
            {
                sp.Read(readbuffer, 0, 22);
                Array.Copy(readbuffer, 4, buffer, 0, 18);
            }
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

            for (int i = 0; i < Sensor.Length; i++)
            {
                Sensor[i] = new SensorPack();

            }


        }
    }
}
