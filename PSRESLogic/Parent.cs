using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Timers;

namespace PSRESLogic
{
    public delegate void SensorDataReadyHandler();

    public abstract class Parent
    {
        public byte Id { get; set; }
        public byte Zone { get; set; }
        public byte parentNumber { get; set; }

        public SensorPack[] Sensor = new SensorPack[3];


        public byte[] buffer = new byte[18];
        protected byte[] readRequestMessage;
        protected Timer timer = new Timer();

        public event SensorDataReadyHandler SensorDataReady;
        

        public void readSensorData(SerialPort sp)
        {

            if (!sp.IsOpen)
            {
                sp.Open();
            }

            sp.Write(readRequestMessage, 0, readRequestMessage.Length);

        }

        public abstract void sensorDataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e);

        protected void timerelapsed(object sender, ElapsedEventArgs e)
        {
            onDataReady();
        }
        protected void TranslateRecivedData(byte[] databuffer)
        {
            byte[] subbuffer = new byte[6];
            for (int i = 0; i < 3; i++)
            {
                Array.Copy(databuffer, i * 6, subbuffer, 0, 6);
                Sensor[i].Update(subbuffer);
            }
        }

        protected virtual void onDataReady()
        {
            (SensorDataReady as SensorDataReadyHandler)?.Invoke();
        }

        public Parent(byte parentnumber, int delay)
        {
            parentNumber = parentnumber;

            for (int i = 0; i < Sensor.Length; i++)
            {
                Sensor[i] = new SensorPack();
            }

            timer.Elapsed += timerelapsed;
            timer.AutoReset = false;
            timer.Interval = delay;
        }

    }
}
