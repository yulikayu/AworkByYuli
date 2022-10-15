using AutoMapper;
using AWork.Contracts.Dto.Purchasing;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.Purchasing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Services.Purchasing
{
    public class PurchaseOrderDetailsService : IPurchaseOrderDetailService
    {
        private IPurchasingRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public PurchaseOrderDetailsService(IPurchasingRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }
        public void Edit(PurchaseOrderDetailsDto purchaseOrderDetailsDto)
        {
            var PurchaseODModel = _mapper.Map<PurchaseOrderDetail>(purchaseOrderDetailsDto);
            _repositoryManager.PurchaseOrderDetailRepository.Edit(PurchaseODModel);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<PurchaseOrderDetailsDto>> GetAllPurchaseOD(bool trackChanges)
        {
            var PurchaseODModel = await _repositoryManager.PurchaseOrderDetailRepository.GetAllPurchaseOrderDetail(false);
            var PurchaseODDto = _mapper.Map<IEnumerable<PurchaseOrderDetailsDto>>(PurchaseODModel);
            return PurchaseODDto;
        }

        public async Task<PurchaseOrderDetailsDto> GetPurchaseODById(int purchaseODId, bool trackChanges)
        {
            var PurchaseODModel = await _repositoryManager.PurchaseOrderDetailRepository.GetPurchaseOrderDetailById(purchaseODId, trackChanges);
            var PurchaseODDto = _mapper.Map<PurchaseOrderDetailsDto>(PurchaseODModel);
            return PurchaseODDto;
        }

        public void Insert(PurchaseOrderDetailsForCreateDto purchaseOrderDetailsForCreateDto)
        {
            var PurchaseODModel = _mapper.Map<PurchaseOrderDetail>(purchaseOrderDetailsForCreateDto);
            _repositoryManager.PurchaseOrderDetailRepository.Insert(PurchaseODModel);
            _repositoryManager.Save();
        }

        public void Remove(PurchaseOrderDetailsDto purchaseOrderDetailsDto)
        {
            var PurchaseODModel = _mapper.Map<PurchaseOrderDetail>(purchaseOrderDetailsDto);
            _repositoryManager.PurchaseOrderDetailRepository.Remove(PurchaseODModel);
            _repositoryManager.Save();
        }
    }
}
