﻿using System;
using System.Collections.Generic;

namespace Core.Models {
    public class Outcome {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }
        public List<Operation> Operations { get; set; }

    }

}
