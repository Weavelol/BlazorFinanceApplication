﻿namespace Core.Models {
    public class OperationType : AbstractModel {
        public bool IsIncome { get; set; }

        public OperationType() {
            IsIncome = true;
        }
    }
}
