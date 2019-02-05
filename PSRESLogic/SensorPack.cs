﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace PSRESLogic
{
    public delegate void PresenceChangedHandler(bool presence);
    public class SensorPack
    {

        private List<double> Temperature = new List<double>();
        private List<double> Illumination = new List<double>();
        private List<double> Distance = new List<double>();
        private List<bool> Presence = new List<bool>();
        private byte Position;
        private byte IDC;
        private byte ParentId;

        public event PresenceChangedHandler PresenceChanged;



        public InstantSensorData GetLatestData()
        {
            InstantSensorData data = new InstantSensorData();
            data.Temperature = Temperature.LastOrDefault();
            data.Distance = Distance.LastOrDefault();
            data.Presence = Presence.LastOrDefault(); ;
            data.Illumination = Illumination.LastOrDefault();

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
        }

        private void TranslatePresence(byte v)
        {
            bool newpresence = v >= 128;

            if (newpresence!=Presence.LastOrDefault() && newpresence==true)
            {
                onPreseneChanged(newpresence);
            }
            Presence.Add(newpresence);

        }

        protected virtual void onPreseneChanged(bool newpresence)
        {
            (PresenceChanged as PresenceChangedHandler)?.Invoke(newpresence);
        }

        private void TranslateIllumination(byte[] illumstring)
        {
            double newIllumination= ((illumstring[0] << 8) | (illumstring[1])) / 1.2;
            Illumination.Add(newIllumination);
        }

        private void TranslateDistance(byte[] diststring)
        {
            double newDistance=(((diststring[0] & 0x78) << 8) + diststring[1]) * 0.017;
            Distance.Add(newDistance);
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

            Temperature.Add(temperature);
        }
    }


}
