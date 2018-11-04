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


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Temperature: "+Temperature.ToString());
            sb.AppendLine("Illumination: " + Illumination.ToString());
            sb.AppendLine("Distance: " + Distance.ToString());
            sb.AppendLine("Presence: " + Presence.ToString());
            return sb.ToString();
        }
    }
}
