using AWork.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Domain.Repositories.Purchasing
{
    public interface IPurchaseOrderDetailRepository
    {
        Task<IEnumerable<PurchaseOrderDetail>> GetAllPurchaseOrderDetail(bool trackChanges);

        Task<PurchaseOrderDetail> GetPurchaseOrderDetailById(int id, bool trackChanges);

        void Insert(PurchaseOrderDetail purchaseOrderDetail);

        void Edit(PurchaseOrderDetail purchaseOrderDetail);

        void Remove(PurchaseOrderDetail purchaseOrderDetail);
    }
}
