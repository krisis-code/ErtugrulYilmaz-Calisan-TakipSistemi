using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeLeaveAllocationRepository employeeLeaveAllocation { get; }
        IEmployeeLeaveRequestRepository employeeLeaveRequest { get; }
        IEmployeeLeaveTypeRepository employeeLeaveType { get; }
        void save();
    }
}
