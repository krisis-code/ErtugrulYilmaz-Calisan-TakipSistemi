using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeLeaveAllocationRepository employeeLeaveAllocationRepository { get; }
        IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; }
        IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; }
        void save();
    }
}
