using PSRESLogic;
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
        public int Zone { get; set; }
        public int parentNumber { get; set; }

        public SensorPack[] Sensor = new SensorPack[3];

    }
}
