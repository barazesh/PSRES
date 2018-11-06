using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    public class SensorRecording
    {
        public int Id { get; set; }
        public int SensoringStationId { get; set; }
        public int TimeDateId { get; set; }
        public double Temperature { get; set; }
        public double Illumination { get; set; }
        public double Distance { get; set; }
        public bool Presence { get; set; }
        public bool Reliable { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Temperature.ToString()+",");
            sb.Append(Illumination.ToString() + ",");
            sb.Append(Distance.ToString() + ",");
            sb.Append(Presence.ToString()+",");
            sb.Append(Reliable.ToString() + ",");
            return sb.ToString();
        }
    }
}
