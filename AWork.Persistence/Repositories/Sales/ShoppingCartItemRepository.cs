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
    internal class ShoppingCartItemRepository : RepositoryBase<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(ShoppingCartItem shoppingCartItem)
        {
            Update(shoppingCartItem);
        }

        public async Task<IEnumerable<ShoppingCartItem>> GetAllShoppingCartItem(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.ShoppingCartItemId).ToListAsync();
        }

        public async Task<ShoppingCartItem> GetShoppingCartItemById(int shoppingCartItemId, bool trackChanges)
        {
            return await FindByCondition(c => c.ShoppingCartItemId.Equals(shoppingCartItemId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(ShoppingCartItem shoppingCartItem)
        {
            Create(shoppingCartItem);
        }

        public void Remove(ShoppingCartItem shoppingCartItem)
        {
            Delete(shoppingCartItem);
        }
    }
}
