using System.ComponentModel.DataAnnotations.Schema;

namespace PSRESData.Entities
{
    public class SensorRecordingEntity
    {
        public int Id { get; set; }

        public SensoringStationEntity sensoringStation { get; set; }
        [ForeignKey("sensoringStation")]
        public int SensoringStationId { get; set; }

        public TimeDateEntity datetime { get; set; }
        [ForeignKey("datetime")]
        public int TimeDateId { get; set; }

        public double Temperature { get; set; }
        public double Illumination { get; set; }
        public double Distance { get; set; }
        public bool Presence { get; set; }

    }
}