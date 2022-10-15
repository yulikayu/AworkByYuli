using AWork.Contracts.Dto.PersonModule;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Abstraction.PersonModul
{
    public interface IPersonServices
    {
        Task<IEnumerable<PersonDto>> GetAllPerson(bool trackChanges);
        Task<PersonDto> GetAllPersonById(int personId, bool trackChanges);
        void Insert(PersonForCreateDto personForCreateDto);
        void Edit(PersonDto personDto);
        void Delete(PersonDto personDto);
    }
}
