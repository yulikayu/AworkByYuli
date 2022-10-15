/*using AutoMapper;
using AWork.Contracts.Dto.Purchasing;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Persistence;
using AWork.Persistence.Base;
using AWork.Persistence.Repositories.Purchasing;
using AWork.Services;
using AWork.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Northwind.Contracts.Dto.Category;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AWork.Test
{
    public class AWorkIntegrationTest
    {
        private static IConfigurationRoot Configuration;
        private static DbContextOptionsBuilder<AdventureWorks2019Context> optionsBuilder;

        private static MapperConfiguration mapperConfig;
        private static IMapper mapper;
        private static IServiceProvider serviceProvider;
        private static IPurchasingRepositoryManager repositoryManager;

        public AWorkIntegrationTest()
        {
            BuilderConfiguration();
            SetupOptions();
        }

        //ini product vendor
        [Fact]
        public void TestGetProductVendorService()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);
                IPurchasingServiceManager serviceManager = new PurchasingServiceManager(repositoryManager, mapper);

                var productVendor = serviceManager.ProductVendorService.GetAllProductVendor(false);

                //assert
                productVendor.ShouldNotBeNull();
                productVendor.Result.Count().ShouldBe(460);
            }
        }

        [Fact]
        public void TestCreateProductVendorService()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);
                IPurchasingServiceManager serviceManager = new pur(repositoryManager, mapper);

                var productVendorDto = new ProductVendorForCreateDto
                {
                    AverageLeadTime = 18,
                    StandardPrice = 60,
                    LastReceiptCost = 65,
                    LastReceiptDate = new DateTime(2022, 4, 18),
                    MinOrderQty = 2,
                    MaxOrderQty = 8,
                    OnOrderQty = 5,
                    UnitMeasureCode = "CTN"
                };
                serviceManager.ProductVendorService.Insert(productVendorDto);

                //assert
                productVendorDto.CategoryName.ShouldSatisfyAllConditions();
            }
        }*//*
        
        [Fact]
        public void TestGetVendorService()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);
                IPurchasingServiceManager serviceManager = new PurchasingServiceManager(repositoryManager, mapper);

                var Vendor = serviceManager.VendorService.GetAllVendor(false);

                //assert
                Vendor.ShouldNotBeNull();
                Vendor.Result.Count().ShouldBe(106);
            }
        }

        [Fact]
         public void TestEditPurchaseService()
         {
             using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
             {
                 repositoryManager = new PurchasingRepositoryManager(context);
                 IPurchasingServiceManager serviceManager = new PurchasingServiceManager(repositoryManager, mapper);
                 var purchaseDto = new PurchaseOrderHeaderDto
                 {

                     ShipDate = DateTime.Today.AddDays(1),
                     PurchaseOrderId = 2,
                     OrderDate = DateTime.Now.AddDays(2),
                     Status = 3,
                     Freight = 7
                 };
                 serviceManager.PurchaseOrderHeaderService.Edit(purchaseDto);
                 var purchaseOH = repositoryManager.PurchaseOrderHeaderRepository.GetAllPurchaseOH(false);
                 purchaseOH.ShouldNotBeNull();
                 purchaseOH.Result.Count().ShouldBe(104);
             }
         }*//*
         
        [Fact]
        public void TestCreatePurchaseService()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);
                IPurchasingServiceManager serviceManager = new PurchasingServiceManager(repositoryManager, mapper);
                var purchaseDto = new PurchaseOrderHeaderForCreateDto
                {
                    VendorId = 1680,
                    EmployeeId = 254,
                    RevisionNumber = 2,
                    ShipMethodId = 5,
                };
                serviceManager.PurchaseOrderHeaderService.Insert(purchaseDto);
                purchaseDto.PurchaseOrderId.ShouldSatisfyAllConditions();
            }
        }

        [Fact]
        public void TestEditPurchaseService()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);
                IPurchasingServiceManager serviceManager = new PurchasingServiceManager(repositoryManager, mapper);
                var purchaseDto = new PurchaseOrderHeaderDto
                {
                    //PurchaseOrderId = 1,
                    VendorId = 1580,
                    EmployeeId = 258,
                    RevisionNumber = 2,
                    ShipMethodId = 3,
                };
                serviceManager.PurchaseOrderHeaderService.Edit(purchaseDto);
                purchaseDto.ShouldSatisfyAllConditions();
            }
        }
        [Fact]
        public void TestRemovePurchaseService()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);
                IPurchasingServiceManager serviceManager = new PurchasingServiceManager(repositoryManager, mapper);
                var purchaseDto = new PurchaseOrderHeaderDto
                {
                    PurchaseOrderId = 4042,
                    VendorId = 1580,
                    EmployeeId = 258,
                    RevisionNumber = 2,
                    ShipMethodId = 5,
                };
                serviceManager.PurchaseOrderHeaderService.Remove(purchaseDto);
                purchaseDto.ShouldSatisfyAllConditions();
            }
        }

        *//*
        [Fact]
        public void TestCreatePurchaseOHRepo()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _purchasingRepository = new PurchasingRepositoryManager(context);
                var purchaseOHModel = new PurchaseOrderHeader
                {
                    ShipDate = DateTime.Now,
                };
                _purchasingRepository.PurchaseOrderHeaderRepository.Insert(purchaseOHModel);
                var purchaseOH = _purchasingRepository.PurchaseOrderHeaderRepository.GetAllPurchaseOrderHeader(false);
                purchaseOH.ShouldNotBeNull();
                purchaseOH.Result.Count().ShouldBe(4012);
            }
        }*//*
        
        [Fact]
        public void TestEditPurchaseOHRepo()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _purchasingRepository = new PurchasingRepositoryManager(context);
                var purchaseOHModel = new PurchaseOrderHeader
                {
                    PurchaseOrderId = 2,
                    ShipDate = DateTime.Now.AddDays(1),
                    Status = 3,
                };
                _purchasingRepository.PurchaseOrderHeaderRepository.Edit(purchaseOHModel);
                var purchaseOH = _purchasingRepository.PurchaseOrderHeaderRepository.GetAllPurchaseOH(false);
                purchaseOH.ShouldNotBeNull();
                purchaseOH.Result.Count().ShouldBe(4012);
            }
        }*//*

        [Fact]
        public void TestGetPurchaseOHService()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);
                IPurchasingServiceManager serviceManager = new PurchasingServiceManager(repositoryManager, mapper);
                var purchase = serviceManager.PurchaseOrderHeaderService.GetAllPurchaseOH(false);
                purchase.ShouldNotBeNull();
                purchase.Result.Count().ShouldBe(4012);
            }
        }



        [Fact]
        public void TestGetPurchaseODRepo()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);
                var purchaseOH = repositoryManager.PurchaseOrderDetailRepository.GetAllPurchaseOrderDetail(false);
                purchaseOH.ShouldNotBeNull();
                purchaseOH.Result.Count().ShouldBe(8845);
            }
        }
        [Fact]
        public void TestCreatePurchaseODRepo()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                repositoryManager = new PurchasingRepositoryManager(context);

                var purchaseODModel = new PurchaseOrderDetail
                {
                    //PurchaseOrderId =
                };
                repositoryManager.PurchaseOrderDetailRepository.Insert(purchaseODModel);
                repositoryManager.Save();

                var purchase = repositoryManager.PurchaseOrderDetailRepository.GetAllPurchaseOrderDetail(false);
                purchase.ShouldNotBeNull();
                purchase.Result.Count().ShouldBe(8846);
            }
        }
        public void BuilderConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }
        private void SetupOptions()
        {
            optionsBuilder = new DbContextOptionsBuilder<AdventureWorks2019Context>();
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("AdventureWorks2019Db"));

            var services = new ServiceCollection();
            services.AddAutoMapper(typeof(MappingProfile));
            serviceProvider = services.BuildServiceProvider();

            mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            mapperConfig.AssertConfigurationIsValid();
            mapper = mapperConfig.CreateMapper();

        }
    }
}
*/
