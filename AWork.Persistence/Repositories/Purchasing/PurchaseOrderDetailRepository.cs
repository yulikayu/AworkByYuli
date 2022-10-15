using AWork.Domain.Models;
using AWork.Domain.Repositories.Purchasing;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.Purchasing
{
    public class PurchaseOrderDetailRepository : RepositoryBase<PurchaseOrderDetail>, IPurchaseOrderDetailRepository
    {
        public PurchaseOrderDetailRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(PurchaseOrderDetail purchaseOrderDetail)
        {
            Update(purchaseOrderDetail);
        }

        public async Task<IEnumerable<PurchaseOrderDetail>> GetAllPurchaseOrderDetail(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(od=>od.PurchaseOrderDetailId).ToListAsync();
        }

        public async Task<PurchaseOrderDetail> GetPurchaseOrderDetailById(int id, bool trackChanges)
        {
            return await FindByCondition(pod => pod.PurchaseOrderId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(PurchaseOrderDetail purchaseOrderDetail)
        {
            Create(purchaseOrderDetail);
        }

        public void Remove(PurchaseOrderDetail purchaseOrderDetail)
        {
            Remove(purchaseOrderDetail);
        }
    }
}
