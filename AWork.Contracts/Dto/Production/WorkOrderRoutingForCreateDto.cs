﻿using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Contracts.Dto.Production
{
    public class WorkOrderRoutingForCreateDto
    {
        public int WorkOrderId { get; set; }
        public int ProductId { get; set; }
        public short OperationSequence { get; set; }
        public short LocationId { get; set; }
        public DateTime ScheduledStartDate { get; set; }
        public DateTime ScheduledEndDate { get; set; }
        public DateTime? ActualStartDate { get; set; }
        public DateTime? ActualEndDate { get; set; }
        public decimal? ActualResourceHrs { get; set; }
        public decimal PlannedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual LocationDto Location { get; set; }
        public virtual WorkOrderDto WorkOrder { get; set; }
    }
}
