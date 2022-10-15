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
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }

        public void Edit(Person person)
        {
            Update(person);
        }

        public async Task<IEnumerable<Person>> GetAllPerson(bool trackChanges)
        {
            return await FindAll(trackChanges)
                .OrderBy(c => c.BusinessEntityId).ToListAsync();
        }

        public async Task<Person> GetPersonById(int personId, bool trackChanges)
        {
            return await FindByCondition(c => c.BusinessEntityId.Equals(personId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(Person person)
        {
            Create(person);
        }

        public void Remove(Person person)
        {
            Delete(person);
        }
    }
}
