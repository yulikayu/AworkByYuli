using AutoMapper;
using AWork.Contracts.Dto.Purchasing;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Services.Abstraction.Purchasing;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AWork.Services.Purchasing
{
    public class VendorService : IVendorService
    {
        private IPurchasingRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        public VendorService(IPurchasingRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public void Edit(VendorDto vendorDto)
        {
            var vendorModel = _mapper.Map<Vendor>(vendorDto);
            _repositoryManager.VendorRepository.Edit(vendorModel);
            _repositoryManager.Save();
        }

        public async Task<IEnumerable<VendorDto>> GetAllVendor(bool trackChanges)
        {
            var vendorModel = await _repositoryManager.VendorRepository.GetAllVendor(false);
            var vendorDto = _mapper.Map<IEnumerable<VendorDto>>(vendorModel);
            return vendorDto;
        }

        public async Task<VendorDto> GetVendorById(int vendorId, bool trackChanges)
        {
            var vendorModel = await _repositoryManager.VendorRepository.GetVendorById(vendorId, trackChanges);
            var vendorDto = _mapper.Map<VendorDto>(vendorModel);
            return vendorDto;
        }

        public void Insert(VendorForCreateDto vendorForCreateDto)
        {
            var vendorModel = _mapper.Map<Vendor>(vendorForCreateDto);
            _repositoryManager.VendorRepository.Insert(vendorModel);
            _repositoryManager.Save();
        }

        public void Remove(VendorDto vendorDto)
        {
            var vendorModel = _mapper.Map<Vendor>(vendorDto);
            _repositoryManager.VendorRepository.Remove(vendorModel);
            _repositoryManager.Save();
        }
    }
}
