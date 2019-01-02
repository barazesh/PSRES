using System.ComponentModel.DataAnnotations.Schema;

namespace PSRESData.Entities
{
    public class MeterRecordingEntity{
        public int Id { get; set; }

        public MeterEntity meter { get; set; }
        [ForeignKey("meter")]
        public int MeterId { get; set; }

        public TimeDateEntity datetime { get; set; }
        [ForeignKey("datetime")]
        public int TimeDateId { get; set; }

        public int activeEnergy { get; set; }
        public int peakActivePower { get; set; }
        public int reactiveEnergy { get; set; }
        public int peakReactivePower { get; set; }
        public decimal voltage { get; set; }
        public decimal current { get; set; }
        public decimal powerFactor { get; set; }
        public decimal frequency { get; set; }
    }
}