using System;
using System.Collections.Generic;
using System.Linq;

namespace PSRESLogic
{
    public class SensorPackData
    {

        private List<double> Temperature = new List<double>();
        private List<double> Illumination = new List<double>();
        private List<double> Distance = new List<double>();
        private bool Presence;

        public InstantSensorData GetLatestData()
        {
            InstantSensorData data = new InstantSensorData();
            data.Temperature = Temperature.LastOrDefault();
            data.Distance = Distance.LastOrDefault();
            data.Presence = Presence;
            data.Illumination = Illumination.LastOrDefault();

            return data;
        }

        public void Update(byte[] recieveddata)
        {
            byte[] subdata = new byte[2];
            Array.Copy(recieveddata, 0, subdata, 0, 2);
            Temperature.Add(TranslateTemperature(subdata));

            Array.Copy(recieveddata, 2, subdata, 0, 2);
            Distance.Add(TranslateDistance(subdata));

            Array.Copy(recieveddata, 4, subdata, 0, 2);
            Illumination.Add(TranslateIllumination(subdata));
            Presence = recieveddata[4] > 128;
        }

        private double TranslateIllumination(byte[] illumstring)
        {
            return ((illumstring[0] << 8) | (illumstring[1])) / 1.2;
        }

        private double TranslateDistance(byte[] diststring)
        {
            return (((diststring[0]& 0x70) << 8) + diststring[1]) * 0.017;
        }

        private double TranslateTemperature(byte[] tempstring)
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
            return temperature;
        }
    }


}
