using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    public class Lamp
    {
        public int currentIllumination { get; set; }
        public int parent { get; set; }
        public int zone { get; set; }
        public int position { get; set; }
    }
}
