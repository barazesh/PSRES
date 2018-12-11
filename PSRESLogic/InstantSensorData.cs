using System.Text;

namespace PSRESLogic
{
    public class InstantSensorData
    {
        public double Temperature { get; set; }
        public double Illumination { get; set; }
        public double Distance { get; set; }
        public bool Presence { get; set; }



        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Temperature: ");
            sb.AppendLine(Temperature.ToString());

            sb.Append("Illumination: ");
            sb.AppendLine(Illumination.ToString());

            sb.Append("Distance: ");
            sb.AppendLine(Distance.ToString());

            sb.Append("Presence: ");
            sb.AppendLine(Presence.ToString());

            return sb.ToString();
        }
    }
}
