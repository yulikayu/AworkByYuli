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
    public class WorkOrderRoutingRepository : RepositoryBase<WorkOrderRouting>, IWorkOrderRoutingRepository
    {
        public WorkOrderRoutingRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(WorkOrderRouting workOrderRouting)
        {
            //throw new NotImplementedException();
            Update(workOrderRouting);
        }

        public async Task<IEnumerable<WorkOrderRouting>> GetAllRouting(bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindAll(trackChange).OrderBy(c => c.WorkOrderId)
                .Include(e => e.Location)
                .Include(d => d.WorkOrder)
                .ToListAsync();

        }

        public async Task<WorkOrderRouting> GetRoutingById(int id, bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindByCondition(c =>c.WorkOrderId.Equals(id),trackChange)
                .Include(e => e.Location)
                .Include(d => d.WorkOrder)
                .SingleOrDefaultAsync();
        }

        public void Insert(WorkOrderRouting workOrderRouting)
        {
            //throw new NotImplementedException();
            Create(workOrderRouting);
        }

        public void Remove(WorkOrderRouting workOrderRouting)
        {
            //throw new NotImplementedException();
            Delete(workOrderRouting);
        }
    }
}
