using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Domain.Repositories.Production
{
    public interface IWorkOrderRoutingRepository
    {
        Task<IEnumerable<WorkOrderRouting>> GetAllRouting(bool trackChange);
        Task<WorkOrderRouting>GetRoutingById(int id, bool trackChange);
        void Insert (WorkOrderRouting workOrderRouting);
        void Edit (WorkOrderRouting workOrderRouting);
        void Remove(WorkOrderRouting workOrderRouting);
    }
}
