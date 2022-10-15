﻿using AWork.Domain.Models;
using AWork.Domain.Repositories.Production;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.Production
{
    internal class LocationRepository : RepositoryBase<Location>, ILocationRepository
    {
        public LocationRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(Location location)
        {
            Update(location);
        }

        public async Task<IEnumerable<Location>> GetAllLocation(bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindAll(trackChange).OrderBy(c => c.LocationId).ToListAsync();
        }

        public async Task<Location> GetLocationById(short locationId, bool trackChange)
        {
            //throw new NotImplementedException();
            return await FindByCondition(c => c.LocationId.Equals(locationId), trackChange).SingleOrDefaultAsync();
        }

        public void Insert(Location location)
        {
            //throw new NotImplementedException();
            Create(location);
        }

        public void Remove(Location location)
        {
            //throw new NotImplementedException();
            Delete(location);
        }
    }
}
