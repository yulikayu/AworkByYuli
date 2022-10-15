using AutoMapper;
using AWork.Contracts.Dto.Sales.SalesPerson;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.Sales;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Sales
{
    public class SalesPersonService : ISalesPersonService
    {
        private readonly ISalesRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public SalesPersonService(ISalesRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public void Edit(SalesPersonDto salesPersonDto)
        {
            var edit = _mapper.Map<SalesPerson>(salesPersonDto);
            _repositoryManager.SalesPersonRepository.Edit(edit);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<SalesPersonDto>> GetAllSalesPerson(bool trackChanges)
        {
            var salesPersonModel = await _repositoryManager.SalesPersonRepository.GetAllSalesPerson(trackChanges);
            // source = categoryModel, target = CategoryDto
            var salesPersonDto = _mapper.Map<IEnumerable<SalesPersonDto>>(salesPersonModel);
            return salesPersonDto;
        }

        public async Task<SalesPersonDto> GetSalesPersonById(int bussinessEntityId, bool trackChanges)
        {
            var salesPersonModel = await _repositoryManager.SalesPersonRepository.GetSalesPersonById(bussinessEntityId, trackChanges);
            // source = categoryModel, target = CategoryDto
            var salesPersonDto = _mapper.Map<SalesPersonDto>(salesPersonModel);
            return salesPersonDto;
        }

        public void Insert(SalesPersonForCreateDto salesPersonForCreateDto)
        {
            var edit = _mapper.Map<SalesPerson>(salesPersonForCreateDto);
            _repositoryManager.SalesPersonRepository.Insert(edit);
            _repositoryManager.Save();
        }

        public void Remove(SalesPersonDto salesPersonDto)
        {
            var edit = _mapper.Map<SalesPerson>(salesPersonDto);
            _repositoryManager.SalesPersonRepository.Remove(edit);
            _repositoryManager.Save();
        }
    }
}
