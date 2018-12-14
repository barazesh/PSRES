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
            

            sp.Write(readRequestMessage, 0, 2);
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

            for (int i = 0; i < Sensor.Length; i++)
            {
                Sensor[i] = new SensorPack();

            }


        }
    }
}
