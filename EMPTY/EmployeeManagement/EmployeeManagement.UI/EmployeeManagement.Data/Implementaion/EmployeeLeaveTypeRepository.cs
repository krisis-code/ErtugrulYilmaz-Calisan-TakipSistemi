using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Contracts.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeLeaveTypeRepository : Repository<EmployeeLeaveType> , IEmployeeLeaveTypeRepository
    {
        private readonly IEmployeeLeaveTypeRepository _ctx;

        public EmployeeLeaveTypeRepository(EmployeeManagementContext ctx) 
            : base(ctx) 
        {
            
        }
    }
}
