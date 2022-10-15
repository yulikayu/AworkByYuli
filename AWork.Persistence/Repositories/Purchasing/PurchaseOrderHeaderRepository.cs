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
    public class PurchaseOrderHeaderRepository : RepositoryBase<PurchaseOrderHeader>, IPurchaseOrderHeaderRepository
    {
        public PurchaseOrderHeaderRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(PurchaseOrderHeader purchaseOrderHeader)
        {
            Update(purchaseOrderHeader);
        }

        public async Task<IEnumerable<PurchaseOrderHeader>> GetAllPurchaseOH(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(v => v.PurchaseOrderId)
            .ToListAsync();
        }

        public async Task<PurchaseOrderHeader> GetPurchaseOrderHeaderById(int id, bool trackChanges)
        {
            return await FindByCondition(poh => poh.PurchaseOrderId.Equals(id), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(PurchaseOrderHeader purchaseOrderHeader)
        {
            Create(purchaseOrderHeader);
        }

        public void Remove(PurchaseOrderHeader purchaseOrderHeader)
        {
            Delete(purchaseOrderHeader);
        }
    }
}