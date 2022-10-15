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
    internal class ScrapReasonRepository : RepositoryBase<ScrapReason>, IScrapReasonRepository
    {
        public ScrapReasonRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(ScrapReason scrapReason)
        {
            //throw new NotImplementedException();
            Update(scrapReason);
        }

        public async Task<IEnumerable<ScrapReason>> GetAllScrapReason(bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindAll(trackChange).OrderBy(c => c.ScrapReasonId).ToListAsync();
        }

        public async Task<ScrapReason> GetLocationById(short reasonId, bool trackChange)
        {
            //throw new NotImplementedException();
            //return await FindByCondition(c => c.LocationId.Equals(locationId), trackChange).SingleOrDefaultAsync();
            return await FindByCondition(c => c.ScrapReasonId.Equals(reasonId), trackChange).SingleOrDefaultAsync();
        }

        public void Insert(ScrapReason scrapReason)
        {
            //throw new NotImplementedException();
            Create(scrapReason);
        }

        public void Remove(ScrapReason scrapReason)
        {
            //throw new NotImplementedException();
            Delete(scrapReason);
        }
    }
}
