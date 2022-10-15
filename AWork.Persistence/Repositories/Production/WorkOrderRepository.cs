using AWork.Domain.Models;
using AWork.Domain.Repositories.Production;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.Production
{
    public class WorkOrderRepository : RepositoryBase<WorkOrder>, IWorkOrderRepository
    {
        public WorkOrderRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(WorkOrder workOrder)
        {
            //throw new NotImplementedException();
            Update(workOrder);
        }

        public async Task<IEnumerable<WorkOrder>> GetAllOrder(bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindAll(trackChange).OrderBy(c => c.WorkOrderId).ToListAsync();
        }

        public async Task<WorkOrder> GetOrderById(int workId, bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindByCondition(c => c.WorkOrderId.Equals(workId), trackChange).SingleOrDefaultAsync();
        }

        public void Insert(WorkOrder workOrder)
        {
            //throw new NotImplementedException();
            Create(workOrder);
        }

        public void Remove(WorkOrder workOrder)
        {
            //throw new NotImplementedException();
            Delete(workOrder);
        }
    }
}
