using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    class SensorRecording
    {
        public int Id { get; set; }
        public int SensoringStationId { get; set; }
        public int TimeDateId { get; set; }
        public double Tmeperature { get; set; }
        public double Illumination { get; set; }
        public int Distance { get; set; }
        public bool Presence { get; set; }
    }
}
