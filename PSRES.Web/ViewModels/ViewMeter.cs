using PSRESLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.ViewModels
{
    public class ViewMeter
    {
        public int Value { get; set; }
        public string Name { get; set; }

        public List<Meter> Meters { get; set; }
    }
}
