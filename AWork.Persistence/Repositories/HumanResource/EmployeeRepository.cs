using AWork.Domain.Models;
using AWork.Contracts.Dto.HumanResources;
using AWork.Domain.Repositories.HumanResource;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.HumanResource
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Employee>> GetAllEmployee(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.BusinessEntityId)
                .Include( p => p.BusinessEntity)
                .ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int businessEntityId, bool trackChanges)
        {
            return await FindByCondition(c => c.BusinessEntityId.Equals(businessEntityId), trackChanges)
                .Include(p => p.BusinessEntity)
                .SingleOrDefaultAsync();
        }

        public void Insert(Employee employee)
        {
            Create(employee);
        }

        public void Edit(Employee employee)
        {
            Update(employee);
        }

        public void Remove(Employee employee)
        {
            Delete(employee);
        }
    }
}
