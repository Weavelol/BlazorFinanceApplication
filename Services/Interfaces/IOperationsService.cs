﻿using Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces {
    public interface IOperationsService : IService<Operation> {
        
        public Task<IEnumerable<Operation>> GetAllAtDateAsync(DateTime date);
        public Task<IEnumerable<Operation>> GetAllAtPeriodAsync(DateTime startDate, DateTime endDate);
        

    }
}