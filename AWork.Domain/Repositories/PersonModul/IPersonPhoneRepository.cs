using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Domain.Repositories.PersonModul
{
    public interface IPersonPhoneRepository
    {
        Task<IEnumerable<PersonPhone>> GetAllPersonPhone(bool trackChanges);

        Task<PersonPhone> GetPersonPhoneById(int personPhoneId, bool trackChanges);

        void Insert(PersonPhone personPhone);

        void Edit(PersonPhone personPhone);

        void Remove(PersonPhone personPhone);
    }
}
