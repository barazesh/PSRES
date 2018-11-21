using System.Collections.Generic;

namespace PSRES.Data.Entities
{
    public class SensoringStation
    {
        public int Id { get; set; }
        public int Zone { get; set; }
        public int ParentId { get; set; }
        public int ParentPin { get; set; }
        public int PositionId { get; set; }
        public List<SensorRecording> Recordings { get; set; }
    }
}
