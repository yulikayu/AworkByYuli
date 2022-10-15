using AWork.Domain.Models;
using System;
using System.Collections.Generic;

namespace AWork.Contracts.Dto.PersonModule
{
    public class AddressDto
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public int StateProvinceId { get; set; }
        public string PostalCode { get; set; }
        public Guid Rowguid { get; set; }
        public DateTime ModifiedDate { get; set; }


        public virtual StateProvinceDto StateProvince { get; set; }
       /* public virtual ICollection<BusinessEntityDto> BusinessEntityAddresses { get; set; }*/
      /*  public virtual ICollection<SalesOrderDetail> SalesOrderHeaderBillToAddresses { get; set; }
        public virtual ICollection<SalesOrderHeader> SalesOrderHeaderShipToAddresses { get; set; }*/
    }
}
