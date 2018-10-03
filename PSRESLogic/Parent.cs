using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRESLogic
{
    class Parent
    {
        public int Zone { get; set; }
        public Lamp[] LampsUnderCover { get; set; }
        public SensoringStation[] SensoringStationsUnderCover { get; set; }
        public int Position { get; set; }
    }
}
