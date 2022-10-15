using AutoMapper;
using AWork.Contracts.Dto;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.PersonModul;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.PersonService
{
    public class PersonPhoneServices : IPersonPhoneServices
    {
        private IPersonRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public PersonPhoneServices(IPersonRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonPhoneDto>> GetAllPersonPhone(bool trackChanges)
        {
            var personPhoneMdl = await _repositoryManager.PersonPhoneRepository.GetAllPersonPhone(trackChanges);
            var personPhoneDto = _mapper.Map<IEnumerable<PersonPhoneDto>>(personPhoneMdl);
            return personPhoneDto;
        }

        public void Edit(PersonPhoneDto personPhoneDto)
        {
            throw new NotImplementedException();
        }
        public async Task<PersonPhoneDto> GetPersonPhoneById(int personPhoneId, bool trackChanges)
        {
            var personPhoneMdl = await _repositoryManager.PersonPhoneRepository.GetPersonPhoneById(personPhoneId, trackChanges);
            var personPhoneDto = _mapper.Map<PersonPhoneDto>(personPhoneMdl);
            return personPhoneDto;
        }

        public void Insert(PersonPhoneForCreateDto personPhoneForCreateDto)
        {
            var personPhoneMdl = _mapper.Map<PersonPhone>(personPhoneForCreateDto);
            _repositoryManager.PersonPhoneRepository.Insert(personPhoneMdl);
            _repositoryManager.Save();
        }


        public void Remove(PersonPhoneDto personPhoneDto)
        {
            var personPhoneMdl = _mapper.Map<PersonPhone>(personPhoneDto);
            _repositoryManager.PersonPhoneRepository.Remove(personPhoneMdl);
            _repositoryManager.SaveAsync();
        }
    }
}
