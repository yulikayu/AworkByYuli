using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Domain.Repositories.Production
{
    public interface IWorkOrderRepository
    {
        Task<IEnumerable<WorkOrder>> GetAllOrder(bool trackChange);
        Task<WorkOrder> GetOrderById(int workId, bool trackChange);
        void Insert (WorkOrder workOrder);
        void Edit (WorkOrder workOrder);
        void Remove (WorkOrder workOrder);
    }
}
