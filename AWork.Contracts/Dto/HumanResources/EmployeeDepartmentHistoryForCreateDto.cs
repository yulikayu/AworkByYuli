using AWork.Contracts.Dto.HumanResources.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AWork.Contracts.Dto.HumanResources
{
    public class EmployeeDepartmentHistoryForCreateDto
    {
        public int BusinessEntityId { get; set; }
        public short DepartmentId { get; set; }
        public byte ShiftId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        /*public virtual ICollection<EmployeeDto> BusinessEntity { get; set; }
        public virtual ICollection<DepartmentDto> Department { get; set; }
        public virtual ICollection<ShiftDto> Shift { get; set; }*/
    }
}
