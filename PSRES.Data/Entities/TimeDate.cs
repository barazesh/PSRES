using System.Collections.Generic;

namespace PSRES.Data.Entities
{
    public class TimeDate
    {
        public int Id { get; set; }
        public int year { get; set; }
        public byte month { get; set; }
        public byte day { get; set; }
        public byte hour { get; set; }
        public byte minute { get; set; }
        public List<MeterRecording> meterRecordings { get; set; }
        public List<SensorRecording> sensorRecordings { get; set; }
    }
}