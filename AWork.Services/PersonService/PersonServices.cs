using AutoMapper;
using AWork.Contracts.Dto.PersonModule;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.PersonModul;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.PersonService
{
    public class PersonServices : IPersonServices
    {
        private IPersonRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PersonServices(IPersonRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Delete(PersonDto personDto)
        {
            var personMdl = _mapper.Map<Person>(personDto);
            _repositoryManager.PersonRepository.Remove(personMdl);
            _repositoryManager.SaveAsync();
        }

        public void Edit(PersonDto personDto)
        {
            var personMdl = _mapper.Map<Person>(personDto);
            _repositoryManager.PersonRepository.Edit(personMdl);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<PersonDto>> GetAllPerson(bool trackChanges)
        {
            var personMdl = await _repositoryManager.PersonRepository.GetAllPerson(trackChanges);
            var personDto = _mapper.Map<IEnumerable<PersonDto>>(personMdl);
            return personDto;
        }

        public async Task<PersonDto> GetAllPersonById(int personId, bool trackChanges)
        {
            var personMdl = await _repositoryManager.PersonRepository.GetPersonById(personId, trackChanges);
            var personDto = _mapper.Map<PersonDto>(personMdl);
            return personDto;
        }

        public void Insert(PersonForCreateDto personForCreateDto)
        {
            var personMdl = _mapper.Map<Person>(personForCreateDto);
            _repositoryManager.PersonRepository.Insert(personMdl);
            _repositoryManager.Save();
        }
    }
}
