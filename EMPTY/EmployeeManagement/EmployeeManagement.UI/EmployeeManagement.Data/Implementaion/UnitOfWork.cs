using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Contracts.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Implementaion
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmployeeManagementContext _ctx;

        public UnitOfWork(EmployeeManagementContext ctx)
        {
            _ctx = ctx;  
            employeeLeaveAllocation = new EmployeeLeaveAllocationRepository(_ctx);
            employeeLeaveType = new EmployeeLeaveTypeRepository(_ctx);
            employeeLeaveRequest = new EmployeeLeaveRequestRepository(_ctx);
        }

        public IEmployeeLeaveAllocationRepository employeeLeaveAllocation {get; private set;}
        public IEmployeeLeaveRequestRepository employeeLeaveRequest { get; private set;}
        public IEmployeeLeaveTypeRepository employeeLeaveType { get; private set;}

        public void Dispose()
        {
           _ctx.Dispose();
        }

        public void save()
        {
            _ctx.SaveChanges();
        }
    }
}
