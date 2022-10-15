using AWork.Domain.Models;
using AWork.Domain.Repositories.PersonModul;
using AWork.Persistence.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Persistence.Repositories.PersonModul
{
    public class EmailAddressRepository : RepositoryBase<EmailAddress>, IEmailAddressRepository
    {
        public EmailAddressRepository(AdventureWorks2019Context dbContext) : base(dbContext)
        {
        }
        public Task<EmailAddress> CreateEmailAddress()
        {
            throw new NotImplementedException();
        }

        public void Edit(EmailAddress emailAddress)
        {
            Update(emailAddress);

        }

        public async Task<IEnumerable<EmailAddress>> GetAllEmailAddress(bool trackChanges)
        {
            return await FindAll(trackChanges).OrderBy(c => c.EmailAddressId).ToListAsync();
        }

        public async Task<EmailAddress> GetEmailAddressById(int emailAddressId, bool trackChanges)
        {
            return await FindByCondition(c => c.EmailAddressId.Equals(emailAddressId), trackChanges).SingleOrDefaultAsync();
        }

        public void Insert(EmailAddress emailAddress)
        {
            Create(emailAddress);
        }

        public void Remove(EmailAddress emailAddress)
        {
            Delete(emailAddress);
        }
    }
}
