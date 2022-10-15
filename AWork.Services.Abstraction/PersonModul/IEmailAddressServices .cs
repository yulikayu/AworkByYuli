using AWork.Contracts.Dto;
using AWork.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.PersonModul
{
    public interface IEmailAddressServices
    {
        Task<IEnumerable<EmailAddressDto>> GetAllEmailAddress(bool trackChanges);
        Task<EmailAddressDto> GetAllEmailAddressById(int emailAddressId, bool trackChanges);
        void Insert(EmailAddressForCreateDto emailAddressForCreateDto);
        void Edit(EmailAddressDto emailAddressDto);
        void Delete(EmailAddressDto emailAddressDto);
    }
}
