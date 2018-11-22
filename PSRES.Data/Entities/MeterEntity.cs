﻿using System.Collections.Generic;

namespace PSRES.Data.Entities
{
    public class MeterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Serialcode { get; set; }
        public List<MeterRecordingEntity> Recording { get; set; }
    }
}
