using AutoMapper;
using AWork.Contracts.Dto.Sales.SpecialOffer;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Sales
{
    public class SpecialOfferService : ISpecialOfferService
    {
        private readonly ISalesRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public SpecialOfferService(ISalesRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public SpecialOfferDto CreateSpecialOfferProduct(SpecialOfferForCreateDto specialOfferForCreateDto)
        {
            var specialOfferModel = _mapper.Map<SpecialOffer>(specialOfferForCreateDto);
            _repositoryManager.SpecialOfferRepository.Insert(specialOfferModel);
            _repositoryManager.Save();
            var specialOfferDto = _mapper.Map<SpecialOfferDto>(specialOfferModel);
            return specialOfferDto;

        }

        public void Edit(SpecialOfferDto SpecialOfferDto)
        {
            var edit = _mapper.Map<SpecialOffer>(SpecialOfferDto);
            _repositoryManager.SpecialOfferRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<SpecialOfferDto>> GetAllSpecialOffer(bool trackChanges)
        {
            var specialOfferModel = await _repositoryManager.SpecialOfferRepository.GetAllSpecialOffer(trackChanges);
            // source = specialOfferModel, target = specialOfferDto
            var specialOfferDto = _mapper.Map<IEnumerable<SpecialOfferDto>>(specialOfferModel);
            return specialOfferDto;
        }

        public async Task<SpecialOfferDto> GetSpecialOfferById(int specialOfferId, bool trackChanges)
        {
            var specialOfferModel = await _repositoryManager.SpecialOfferRepository.GetSpecialOfferById(specialOfferId, trackChanges);
            // source = specialOfferModel, target = specialOfferDto
            var specialOfferDto = _mapper.Map<SpecialOfferDto>(specialOfferModel);
            return specialOfferDto;
        }

        public void Insert(SpecialOfferForCreateDto specialOfferForCreateDto)
        {
            var edit = _mapper.Map<SpecialOffer>(specialOfferForCreateDto);
            _repositoryManager.SpecialOfferRepository.Insert(edit);
            _repositoryManager.Save();
        }

        public void Remove(SpecialOfferDto specialOfferDto)
        {
            var edit = _mapper.Map<SpecialOffer>(specialOfferDto);
            _repositoryManager.SpecialOfferRepository.Remove(edit);
            _repositoryManager.Save();
        }
    }
}
