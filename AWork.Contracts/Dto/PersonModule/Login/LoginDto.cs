using AWork.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Contracts.Dto.PersonModule.Login
{
    public class LoginDto
    {
        public string Username { get; set; }
        public virtual Password Password { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }


    }
}
