using System.Collections.Generic;
namespace PSRESData.Entities
{
    public class TimeDateEntity
    {
        public int Id { get; set; }
        public int year { get; set; }
        public byte month { get; set; }
        public byte day { get; set; }
        public byte hour { get; set; }
        public byte minute { get; set; }
        public List<MeterRecordingEntity> meterRecordings { get; set; }
        public List<SensorRecordingEntity> sensorRecordings { get; set; }
    }
}