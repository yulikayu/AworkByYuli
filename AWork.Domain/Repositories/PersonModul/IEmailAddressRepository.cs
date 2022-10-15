using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Domain.Repositories.PersonModul
{
    public interface IEmailAddressRepository
    {
        Task<IEnumerable<EmailAddress>> GetAllEmailAddress(bool trackChanges);

        Task<EmailAddress> GetEmailAddressById(int emailAddressId, bool trackChanges);

        void Insert(EmailAddress emailAddress);

        void Edit(EmailAddress emailAddress);

        void Remove(EmailAddress passwoemailAddressrd);
    }
}
