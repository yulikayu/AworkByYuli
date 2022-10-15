using AWork.Domain.Models;
using AWork.Domain.Repositories.PersonModul;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.PersonModul
{
    public class CountryRegionRepository : RepositoryBase<CountryRegion>, ICountryRegionRepository
    {
        public CountryRegionRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(CountryRegion countryRegion)
        {
            Update(countryRegion);
        }

        public async Task<IEnumerable<CountryRegion>> GetAllCountryRegion(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.CountryRegionCode).ToListAsync();
        }

        public async Task<CountryRegion> GetAllCountryRegionByCode(string countryCode, bool trackChanges)
        {
            return await FindByCondition(c => c.CountryRegionCode.Equals(countryCode), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(CountryRegion countryRegion)
        {
            Create(countryRegion);
        }

        public void Remove(CountryRegion countryRegion)
        {
            Delete(countryRegion);
        }
    }
}
