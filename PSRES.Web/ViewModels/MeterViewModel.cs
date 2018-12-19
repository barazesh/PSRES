using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.ViewModels
{
    public class MeterViewModel
    {
        public int Id { get; set; }
        public long SerialCode { get; set; }
        public string Name { get; set; }
        public decimal Voltage { get; set; }
        public decimal Current { get; set; }
        public decimal PowerFactor { get; set; }
        public decimal Frequency { get; set; }
        public decimal ActivePower { get; set; }
        public decimal ReactivePower { get; set; }

    }
}
