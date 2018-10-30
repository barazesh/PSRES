using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    public class MeterRecording
    {
        public int Id { get; set; }
        public Meter meter { get; set; }
        public int MeterId { get; set; }
        public TimeDate datetime { get; set; }
        public int TimeDateId { get; set; }
        public decimal activeEnergy { get; set; }
        public decimal reactiveEnergy { get; set; }
        public int activePower { get; set; }
        public int reactivePower { get; set; }
        public decimal voltage { get; set; }
        public decimal current { get; set; }
        public decimal powerFactor { get; set; }
        public decimal frequency { get; set; }

    }
}
