using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Contracts.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeLeaveAllocationRepository : Repository<EmployeeLeaveAllocation>, IEmployeeLeaveAllocationRepository
    {
        private readonly EmployeeManagementContext _ctx;

        public EmployeeLeaveAllocationRepository(EmployeeManagementContext ctx)
         : base(ctx)
        {
            _ctx = ctx;
        }

    }
}
