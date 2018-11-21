using System.Collections.Generic;

namespace PSRES.Data.Entities
{
    public class Meter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Serialcode { get; set; }
        public List<MeterRecording> Recording { get; set; }
    }
}
