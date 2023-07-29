using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Contracts.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeLeaveRequestRepository : Repository<EmployeeLeaveRequest> ,IEmployeeLeaveRequestRepository
    {
        private readonly EmployeeLeaveRequest _ctx;

        public EmployeeLeaveRequestRepository(EmployeeManagementContext ctx) : base(ctx)
        {

        }
    }
}
