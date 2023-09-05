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
			employeeLeaveAllocationRepository = new EmployeeLeaveAllocationRepository(_ctx);
			employeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(_ctx);
			employeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(_ctx);
			employeeRepository = new EmployeeRepository(_ctx);
		}

        public IEmployeeLeaveAllocationRepository employeeLeaveAllocationRepository { get; private set;}
        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set;}
        public IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; private set;}
		public IEmployeeRepository employeeRepository { get; private set; }



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
