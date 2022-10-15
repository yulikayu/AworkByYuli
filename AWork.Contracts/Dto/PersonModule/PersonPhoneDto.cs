using System;

namespace AWork.Contracts.Dto
{
    public class PersonPhoneDto
    {
        public int BusinessEntityId { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
