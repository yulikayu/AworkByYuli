using AWork.Domain.Models;
using AWork.Domain.Repositories.Production;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.Production
{
    internal class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void edit(ProductCategory productCategory)
        {
            Update(productCategory);
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProdcCategory(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.ProductCategoryId).ToListAsync();
        }

        public async Task<ProductCategory> GetProcdCateById(int prodcCategory, bool trackChanges)
        {
            return await FindByCondition(c => c.ProductCategoryId.Equals(prodcCategory), trackChanges).SingleOrDefaultAsync();
        }

        public void insert(ProductCategory productCategory)
        {
            Create(productCategory);
        }

        public void remove(ProductCategory productCategory)
        {
            Delete(productCategory);
        }
    }
}
