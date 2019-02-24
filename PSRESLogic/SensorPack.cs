using System;
using System.Collections.Generic;
using System.Linq;

namespace PSRESLogic
{
    public delegate void PresenceChangedHandler();
    public class SensorPack
    {

        private List<double> Temperature = new List<double>();
        private List<double> Illumination = new List<double>();
        private List<double> Distance = new List<double>();
        private List<bool> Presence = new List<bool>();
        private byte Position;
        private byte IDC;
        private byte ParentId;
        public InstantSensorData latestData { get; private set; }

        public event PresenceChangedHandler ShowUp;
        protected virtual void onShowUp()
        {
            (ShowUp as PresenceChangedHandler)?.Invoke();
        }

        public event PresenceChangedHandler Leave;
        protected virtual void onLeave()
        {
            (Leave as PresenceChangedHandler)?.Invoke();
        }

        public InstantSensorData GetLatestReading()
        {
            InstantSensorData data = new InstantSensorData();
            data.Temperature = Temperature.LastOrDefault();
            data.Presence = Presence.LastOrDefault();
            data.Illumination = Illumination.LastOrDefault();
            data.Distance = Distance.LastOrDefault();

            return data;
        }

        public void Update(byte[] recieveddata)
        {
            byte[] subdata = new byte[2];
            Array.Copy(recieveddata, 0, subdata, 0, 2);
            TranslateTemperature(subdata);

            Array.Copy(recieveddata, 4, subdata, 0, 2);
            TranslateDistance(subdata);

            Array.Copy(recieveddata, 2, subdata, 0, 2);
            TranslateIllumination(subdata);

            TranslatePresence(recieveddata[4]);
            if (EvaluateData())
            {
                if (DetectShowUp())
                {
                    onShowUp();
                }
                else if(DetectLeave())
                {
                    onLeave();
                }

                Presence.Add(latestData.Presence);
                Illumination.Add(latestData.Illumination);
                Distance.Add(latestData.Distance);
                Temperature.Add(latestData.Temperature);
            }
        }

        private bool DetectLeave()
        {
            bool PresenceSensorDetection = (latestData.Presence == false && Presence.LastOrDefault() == true);

            bool DistanceSensorDetection = (latestData.Distance > 120 && Distance.LastOrDefault() < 120)&&false;

            return (DistanceSensorDetection || PresenceSensorDetection);
        }


        private bool DetectShowUp()
        {

            bool PresenceSensorDetection = (latestData.Presence == true && Presence.LastOrDefault() == false);

            bool DistanceSensorDetection = (latestData.Distance < 120 && Distance.LastOrDefault() > 120)&&false;

            return (DistanceSensorDetection || PresenceSensorDetection);
        }

        private bool EvaluateData()
        {
            bool distanceElligible = (latestData.Distance < 270 && latestData.Distance > 2);

            bool temperatureElligible = (latestData.Temperature < 60);

            bool illuminationElligible = (latestData.Illumination < 3000);

            return (distanceElligible && temperatureElligible && illuminationElligible);

        }

        private void TranslatePresence(byte v)
        {
            bool newpresence = v >= 128;

            latestData.Presence = newpresence;
        }

        private void TranslateIllumination(byte[] illumstring)
        {
            double newIllumination= ((illumstring[0] << 8) | (illumstring[1])) / 1.2;
            latestData.Illumination = newIllumination;
        }

        private void TranslateDistance(byte[] diststring)
        {
            double newDistance=(((diststring[0] & 0x7F) << 8) + diststring[1]) * 0.017;
            latestData.Distance = newDistance;
        }

        private void TranslateTemperature(byte[] tempstring)
        {
            int temp = (tempstring[0] << 8) | tempstring[1];
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
            latestData.Temperature = temperature;
        }

        public SensorPack()
        {
            latestData = new InstantSensorData();
        }
    }
}
