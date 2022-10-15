using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Contracts.Dto.PersonModule.Profile
{
    public class ProfileDto
    {
        public virtual ICollection<Person> Person { get; set; }
        public virtual ICollection<EmailAddress> EmailAddresses { get; set;  }
        public virtual ICollection<PhoneNumberType> PhoneNumberTypes { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }

    }
}
