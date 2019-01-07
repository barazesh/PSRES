using System.Collections.Generic;
namespace PSRESData.Entities
{
    public class SensoringStationEntity
    {
        public byte Id { get; set; }
        public byte Zone { get; set; }
        public byte ParentId { get; set; }
        public byte ParentPin { get; set; }
        public byte PositionId { get; set; }
        public List<SensorRecordingEntity> Recordings { get; set; }
    }
}