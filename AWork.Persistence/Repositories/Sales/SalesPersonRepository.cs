using AWork.Domain.Models;
using AWork.Domain.Repositories.Sales;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.Sales
{
    public class SalesPersonRepository : RepositoryBase<SalesPerson>, ISalesPersonRepository
    {
        public SalesPersonRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(SalesPerson salesTeritory)
        {
            Update(salesTeritory);
        }

        public async Task<IEnumerable<SalesPerson>> GetAllSalesPerson(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(b => b.BusinessEntityId)
                .Include(e => e.BusinessEntity)
                .Include(t => t.Territory)
                .ToListAsync();
        }

        public async Task<SalesPerson> GetSalesPersonById(int businessEntityId, bool trackChanges)
        {
            return await FindByCondition(b => b.BusinessEntityId.Equals(businessEntityId), trackChanges)
                .Include(e => e.BusinessEntity)
                .Include(t => t.Territory)
                .SingleOrDefaultAsync();
        }

        public void Insert(SalesPerson salesTeritory)
        {
            Create(salesTeritory);
        }

        public void Remove(SalesPerson salesTeritory)
        {
            Delete(salesTeritory);
        }
    }
}
