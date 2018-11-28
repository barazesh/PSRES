using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.ViewModels
{
    public class SensorViewModel
    {
        public int Id { get; set; }
        public bool SelectAll { get; set; }
        public double Temperature { get; set; }
        public double Distnace { get; set; }
        public double Illumination { get; set; }
        public bool Presence { get; set; }
    }
}
