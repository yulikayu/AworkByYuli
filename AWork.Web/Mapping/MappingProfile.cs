﻿using AutoMapper;

using AWork.Contracts.Dto.Production;
using AWork.Contracts.Dto.Sales.SalesPerson;
using AWork.Contracts.Dto.Sales.SalesTerritory;
using AWork.Domain.Models;
using AWork.Contracts.Dto.Purchasing;
using AWork.Contracts.Dto.Sales.SalesOrderHeader;
using AWork.Contracts.Dto.Sales.CreditCard;
using AWork.Contracts.Dto.Sales.PersonCreditCard;
using AWork.Contracts.Dto.PersonModule;
using AWork.Contracts.Dto.Sales.SpecialOffer;
using AWork.Contracts.Dto.Sales.SalesOfferProduct;
using AWork.Contracts.Dto.HumanResources.Employee;
using AWork.Contracts.Dto.HumanResources;
using AWork.Contracts.Dto.HumanResources.Employee;
using AWork.Contracts.Dto.HumanResources.EmployeePayHistory;
using AWork.Contracts.Dto.HumanResources.JobCandidate;

namespace AWork.Domain.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeForCreateDto>().ReverseMap();

            CreateMap<EmployeePayHistory, EmployeePayHistoryDto>().ReverseMap();
            CreateMap<EmployeePayHistory, EmployeePHForCreateDto>().ReverseMap();

            CreateMap<JobCandidate, JobCandidateDto>().ReverseMap();
            CreateMap<JobCandidate, JobCandidateForCreateDto>().ReverseMap();

            CreateMap<BusinessEntity, BusinessEntityDto>().ReverseMap();
            CreateMap<BusinessEntity, BusinessEntityForCreateDto>().ReverseMap();

            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<Address, AddressForCreateDto>().ReverseMap();

            CreateMap<ContactType, ContactTypeDto>().ReverseMap();
            CreateMap<ContactType, ContactTypeForCreateDto>().ReverseMap();

            CreateMap<CountryRegion, CountryRegionDto>().ReverseMap();
            CreateMap<CountryRegion, CountryRegionForCreateDto>().ReverseMap();

            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, PersonForCreateDto>().ReverseMap();

            CreateMap<StateProvince, StateProvinceDto>().ReverseMap();
            CreateMap<StateProvince, StateProvinceForCreateDto>().ReverseMap();

            CreateMap<ProductPhoto, ProductPhotoDto>().ReverseMap();
            CreateMap<ProductPhoto, ProductPhotoForCreateDto>().ReverseMap();


            CreateMap<ShipMethod, ShipMethodDto>().ReverseMap();
            CreateMap<ShipMethod, ShipMethodForCreateDto>().ReverseMap();

            CreateMap<Vendor, VendorDto>().ReverseMap();
            CreateMap<Vendor, VendorForCreateDto>().ReverseMap();
            CreateMap<ProductVendor, ProductVendorDto>().ReverseMap();
            CreateMap<ProductVendor, ProductVendorForCreateDto>().ReverseMap();
            CreateMap<PurchaseOrderHeader, PurchaseOrderHeaderDto>().ReverseMap();
            CreateMap<PurchaseOrderHeader, PurchaseOrderHeaderForCreateDto>().ReverseMap();
            CreateMap<PurchaseOrderDetail, PurchaseOrderDetailsDto>().ReverseMap();
            CreateMap<PurchaseOrderDetail, PurchaseOrderDetailsForCreateDto>().ReverseMap();


            CreateMap<ProductCategory, ProductCategoryDto>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryForCreatDto>().ReverseMap();
            CreateMap<ProductSubcategory, ProductSubCategoryDto>().ReverseMap();
            CreateMap<ProductSubcategory, ProductSubCategoryForCreateDto>().ReverseMap();

            CreateMap<Department, DepartmentDto>().ReverseMap();
            CreateMap<Department, DepartmentForCreateDto>().ReverseMap();

            CreateMap<Shift, ShiftDto>().ReverseMap();
            CreateMap<Shift, ShiftForCreateDto>().ReverseMap();

            CreateMap<EmployeeDepartmentHistory, EmployeeDepartmentHistoryDto>().ReverseMap();
            CreateMap<EmployeeDepartmentHistory, EmployeeDepartmentHistoryForCreateDto>().ReverseMap();


            CreateMap<UnitMeasure, UnitMeasureDto>().ReverseMap();
            CreateMap<UnitMeasure, UnitMeasureForCreateDto>().ReverseMap();


            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Location, LocationForCreateDto>().ReverseMap();

            CreateMap<SalesTerritory, SalesTerritoryDto>().ReverseMap();
            CreateMap<SalesTerritory, SalesTerritoryForCreateDto>().ReverseMap();

            CreateMap<SalesPerson, SalesPersonDto>().ReverseMap();
            CreateMap<SalesPerson, SalesPersonForCreateDto>().ReverseMap();

            CreateMap<SalesOrderHeader, SalesOrderHeaderDto>().ReverseMap();
            CreateMap<SalesOrderHeader, SalesOrderHeaderForCreateDto>().ReverseMap();

            CreateMap<CreditCard, CreditCardDto>().ReverseMap();
            CreateMap<CreditCard, CreditCardForCreateDto>().ReverseMap();

            CreateMap<PersonCreditCard, PersonCreditCardDto>().ReverseMap();
            CreateMap<PersonCreditCard, PersonCreditCardForCreateDto>().ReverseMap();

            CreateMap<SpecialOffer, SpecialOfferDto>().ReverseMap();
            CreateMap<SpecialOffer, SpecialOfferForCreateDto>().ReverseMap();

            CreateMap<SpecialOfferProduct, SpecialOfferProductDto>().ReverseMap();
            CreateMap<SpecialOfferProduct, SpecialOfferProductForCreateDto>().ReverseMap();

            CreateMap<WorkOrderRouting, WorkOrderRoutingDto>().ReverseMap();
            CreateMap<WorkOrderRouting, WorkOrderRoutingForCreateDto>().ReverseMap();

            CreateMap<BillOfMaterial, BillOfMaterialDto>().ReverseMap();
            CreateMap<BillOfMaterial, BillOfMaterialForCreateDto>().ReverseMap();
            CreateMap<TransactionHistory, TransactionHistoryDto>().ReverseMap();
            CreateMap<TransactionHistory, TransactionHistoryForCreateDto>().ReverseMap();

            CreateMap<ProductCostHistory, ProductCostHistoryDto>().ReverseMap();
            CreateMap<ProductCostHistory, ProductCategoryForCreatDto>().ReverseMap();

            CreateMap<ProductReview, ProductReviewDto>().ReverseMap();
            CreateMap<ProductReview, ProductReviewForCreateDto>().ReverseMap();


            CreateMap<UnitMeasure, UnitMeasureDto>().ReverseMap();
            CreateMap<UnitMeasure, UnitMeasureForCreateDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductForCreateDto>().ReverseMap();

            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Location, LocationForCreateDto>().ReverseMap();

            CreateMap<ProductInventory, ProductInventoryDto>().ReverseMap();
            CreateMap<ProductInventory, ProductInventoryDtoForCreate>().ReverseMap();

            CreateMap<ScrapReason, ScrapReasonDto>().ReverseMap();
            CreateMap<ScrapReason, ScrapReasonForCreateDto>().ReverseMap();

            CreateMap<WorkOrder, WorkOrderDto>().ReverseMap();
            CreateMap<WorkOrder, WorkOrderForCreateDto>().ReverseMap();
        }
    }
}
