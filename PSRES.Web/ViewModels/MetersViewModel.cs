﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSRES.Web.ViewModels
{
    public class MetersViewModel
    {
        public int Index { get; set; }
        public string Name { get; set; }

        public List<string> MeterNames { get; set; }
        public List<int> MeterIds { get; set; }


    }
}