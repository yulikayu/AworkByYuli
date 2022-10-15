using AutoMapper;
using AWork.Contracts.Dto.PersonModule;
using AWork.Domain.Base;
using AWork.Domain.Models;
using AWork.Persistence;
using AWork.Persistence.Base;
using AWork.Persistence.Repositories.PersonModul;
using AWork.Services;
using AWork.Services.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;



namespace AWork.Test
{
    public class AworkIntegratedTest
    {
        private static IConfigurationRoot Configuration;
        private static DbContextOptionsBuilder<AdventureWorks2019Context> optionsBuilder;
        private static MapperConfiguration mapperConfig;
        private static IMapper mapper;
        private static IServiceProvider serviceProvider;
        private static IPersonRepositoryManager _personRepositoryManager;

        public AworkIntegratedTest()
        {
            BuildConfiguration();
            SetupOption();

        }
      /*  [Fact]
        public void CreateCountryRegion()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var countryRegionDto = new CountryRegionForCreateDto
                {
                    CountryRegionCode = "IN",
                    Name = "Indonesia ",
                    ModifiedDate = DateTime.Now
                };
                serviceManager.CountryRegionServices.Insert(countryRegionDto);
                var countryRegion = serviceManager.CountryRegionServices.GetAllCountryRegion(false);
                countryRegion.ShouldNotBeNull();
                countryRegion.Result.Count().ShouldBe(239);

            }
        }

        //createStateProvince
        [Fact]
        public void CreateStateprovince()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);


                var stateProvinceDto = new StateProvinceForCreateDto
                {
                    StateProvinceCode = "IND",
                    CountryRegionCode = "IN",
                    IsOnlyStateProvinceFlag = true,
                    Name = "Cipedak V",
                    TerritoryId = 6,
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now
                };

                serviceManager.StateProvinceServices.Insert(stateProvinceDto);
                var stateProvince = serviceManager.StateProvinceServices.GetAllStateprovince(false);
                stateProvince.ShouldNotBeNull();
                stateProvince.Result.Count().ShouldBe(182);
            }
        }

        //createAddress
        [Fact]
        public void CreateAdress()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var addressDto = new AddressForCreateDto
                {
                    AddressLine1 = "Jagakarsa",
                    AddressLine2 = "cipedak",
                    City = "jakarta",
                    PostalCode = "12640",
                    StateProvinceId = 9,
                    Rowguid = Guid.NewGuid(),
                    ModifiedDate = DateTime.Now

                };
                serviceManager.AddressServices.Insert(addressDto);
                var address = serviceManager.AddressServices.GetAllAddress(false);
                address.ShouldNotBeNull();
                address.Result.Count().ShouldBe(19615);
            }
        }

        //CreatePerson
        [Fact]
        public void CreatePerson()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var personDto = new PersonForCreateDto
                {

                    PersonType = "IN",
                    FirstName = "irham",
                    MiddleName = "R",
                    LastName = "Rafi",
                    EmailPromotion = 4
                };

                serviceManager.PersonServices.Insert(personDto);
                var person = serviceManager.PersonServices.GetAllPerson(false);
                person.ShouldNotBeNull();
                person.Result.Count().ShouldBe(19973);

            }
        }

        //CreateContactType
        [Fact]
        public void CreateContactType()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var contactTypeDto = new ContactTypeForCreateDto
                {
                    Name = "Owner Pinjol",
                    ModifiedDate = DateTime.Now
                };

                serviceManager.ContactTypeServices.Insert(contactTypeDto);
                var contactType = serviceManager.ContactTypeServices.GetAllContactType(false);
                contactType.ShouldNotBeNull();
                contactType.Result.Count().ShouldBe(21);
            }
        }

        //createBusinessEntity
        [Fact]
        public void CreateBusinessEntity()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var businessEntityDto = new BusinessEntityForCreateDto
                {
                    ModifiedDate = DateTime.Now,
                    Rowguid = Guid.Empty

                };
                // serviceManager.BusinessEntityServices.Insert(businessEntityDto);
                var businessEntity = serviceManager.BusinessEntityServices.CreateBusinessEntity();
                businessEntity.ShouldNotBeNull();
                businessEntity.BusinessEntityId.ShouldBe(20784);

            }
        }

        [Fact]
        //contactType
        public void GetContactType()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var contact = serviceManager.ContactTypeServices.GetAllContactType(false);
                contact.ShouldNotBeNull();
                contact.Result.Count().ShouldBe(20);
            }
        }
        //countryRegion
        [Fact]
        public void GetCountryRegion()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var countryRegion = serviceManager.CountryRegionServices.GetAllCountryRegion(false);
                countryRegion.ShouldNotBeNull();
                countryRegion.Result.Count().ShouldBe(238);
            }
        }

        //stateProvince
        [Fact]
        public void GetStateprovince()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var stateProvince = serviceManager.StateProvinceServices.GetAllStateprovince(false);
                stateProvince.ShouldNotBeNull();
                stateProvince.Result.Count().ShouldBe(181);
            }
        }

        ////Adress
        [Fact]
        public void GetAddress()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var address = serviceManager.AddressServices.GetAllAddress(false);
                address.ShouldNotBeNull();
                address.Result.Count().ShouldBe(19614);
            }
        }

        

        ////BusinessEntity
        [Fact]
        public void GetBusinessEntity()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var businessEntity = serviceManager.BusinessEntityServices.GetAllBusinessEntity(false);
                businessEntity.ShouldNotBeNull();
                businessEntity.Result.Count().ShouldBe(20777);
            }
        }


        ////personService
        [Fact]
        public void GetPerson()
        {
            using (var context = new AdventureWorks2019Context(optionsBuilder.Options))
            {
                _personRepositoryManager = new PersonRepositoryManager(context);
                IPersonServiceManager serviceManager = new PersonServiceManager(_personRepositoryManager, mapper);

                var person = serviceManager.PersonServices.GetAllPerson(false);

                person.ShouldNotBeNull();
                person.Result.Count().ShouldBe(19972);
            }
        }*/


        private void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        private void SetupOption()
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
