﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassiveLoad.Models
{
    public class ExcelAppointmentResultModel : ExcelModel
    {
        public ExcelModel AptModel { get; set; }

        public bool Success { get; set; }

        public string Error { get; set; }
    }
}
