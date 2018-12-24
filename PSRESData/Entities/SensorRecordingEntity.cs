namespace PSRESData.Entities
{
    public class SensorRecordingEntity
    {
        public int Id { get; set; }
        public int SensoringStationId { get; set; }
        //public int TimeDateId { get; set; }
        public double Temperature { get; set; }
        public double Illumination { get; set; }
        public double Distance { get; set; }
        public bool Presence { get; set; }

    }
}