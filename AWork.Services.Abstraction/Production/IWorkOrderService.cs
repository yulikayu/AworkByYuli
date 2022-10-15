using AWork.Contracts.Dto.Production;
using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.Production
{
    public interface IWorkOrderService
    {
        Task<IEnumerable<WorkOrderDto>> GetAllWorkOrder(bool trackChange);
        Task<WorkOrderDto>GetWorkOrderById(int workOrderId, bool trackChange);
        WorkOrderRoutingDto CreateWorkOrder();
        void Insert (WorkOrderForCreateDto workOrderForCreateDto);
        void Edit(WorkOrderDto workOrderDto);
        void Remove(WorkOrderDto workOrderDto);
    }
}
