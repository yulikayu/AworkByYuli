using AutoMapper;
using AWork.Contracts.Dto.Purchasing;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.Purchasing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Purchasing
{
    public class PurchaseOrderHeaderService : IPurchaseOrderHeaderService
    {
        private readonly IPurchasingRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public PurchaseOrderHeaderService(IPurchasingRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PurchaseOrderHeaderDto>> GetAllPurchaseOH(bool trackChanges)
        {
            var purchaseOHModel = await _repositoryManager.PurchaseOrderHeaderRepository.GetAllPurchaseOH(trackChanges);
            var purchaseOHDto = _mapper.Map<IEnumerable<PurchaseOrderHeaderDto>>(purchaseOHModel);
            return purchaseOHDto;
        }

        public async Task<PurchaseOrderHeaderDto> GetPurchaseOHById(int purchaseOrderOHId, bool trackChanges)
        {
            var purchaseModel = await _repositoryManager.PurchaseOrderHeaderRepository.GetPurchaseOrderHeaderById(purchaseOrderOHId, trackChanges);
            var purchaseDto = _mapper.Map<PurchaseOrderHeaderDto>(purchaseModel);
            return purchaseDto;
        }

        public void Insert(PurchaseOrderHeaderForCreateDto purchaseOrderHeaderForCreateDto)
        {
            var purchaseModel = _mapper.Map<PurchaseOrderHeader>(purchaseOrderHeaderForCreateDto);
            _repositoryManager.PurchaseOrderHeaderRepository.Insert(purchaseModel);
            _repositoryManager.Save();
        }

        public void Edit(PurchaseOrderHeaderDto purchaseOrderHeaderDto)
        {
            var purchaseModel = _mapper.Map<PurchaseOrderHeader>(purchaseOrderHeaderDto);
            _repositoryManager.PurchaseOrderHeaderRepository.Edit(purchaseModel);
            _repositoryManager.Save();
        }

        public void Remove(PurchaseOrderHeaderDto purchaseOrderHeaderDto)
        {
            var purchaseModel = _mapper.Map<PurchaseOrderHeader>(purchaseOrderHeaderDto);
            _repositoryManager.PurchaseOrderHeaderRepository.Remove(purchaseModel);
            _repositoryManager.Save();
        }
    }
}
