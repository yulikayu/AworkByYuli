using AWork.Contracts.Dto.HumanResources.Employee;
using AWork.Contracts.Dto.Sales.PersonCreditCard;
using AWork.Domain.Models;
using System;
using System.Collections.Generic;

namespace AWork.Contracts.Dto.PersonModule
{
    public class PersonDto
    {
        public int BusinessEntityId { get; set; }
        public string PersonType { get; set; }
        public bool NameStyle { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public int EmailPromotion { get; set; }
        public string AdditionalContactInfo { get; set; }
        public string Demographics { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual BusinessEntityDto BusinessEntity { get; set; }
        public virtual EmployeeDto Employee { get; set; }
        //public virtual ICollection<EmployeeDto> BusinessEntity { get; set; }
        public virtual Password Password { get; set; }
        /*public virtual ICollection<BusinessEntityContact> BusinessEntityContacts { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }
        public virtual ICollection<PersonCreditCard> PersonCreditCards { get; set; }
        public virtual ICollection<PersonPhone> PersonPhones { get; set; }*/
    }
}
