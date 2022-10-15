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
    internal class ProductInventoryRepository : RepositoryBase<ProductInventory>, IProductInventoryRepository
    {
        public ProductInventoryRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(ProductInventory productInventory)
        {
            //throw new NotImplementedException();
            Update(productInventory);
        }

        public async Task<IEnumerable<ProductInventory>> GetAllInventory(bool trackChange)
        {
            //throw new NotImplementedException();
            //penambahan Include
            return await FindAll(trackChange).OrderBy(c => c.ProductId)
                .Include(a => a.Location)
                .Include(p => p.Product)
                .ToListAsync();
        }

        public async Task<ProductInventory> GetInventoryById(int inventoryId, bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindByCondition(c => c.ProductId.Equals(inventoryId),trackChange)
                .Include(p => p.Product)
                .Include(a => a.Location)
                .SingleOrDefaultAsync();
        }

        public void Insert(ProductInventory productInventory)
        {
            //throw new NotImplementedException();
            Create(productInventory);
        }

        public void Remove(ProductInventory productInventory)
        {
            //throw new NotImplementedException();
            Delete(productInventory);
        }
    }
}
