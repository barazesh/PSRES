using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.ViewModels
{
    public class LampViewModel
    {
        public int Index { get; set; }
        public byte DutyCycle { get; set; }
        public byte Frequency { get; set; }
        public bool All { get; set; }
        public string controltype { get; set; }
    }
}
