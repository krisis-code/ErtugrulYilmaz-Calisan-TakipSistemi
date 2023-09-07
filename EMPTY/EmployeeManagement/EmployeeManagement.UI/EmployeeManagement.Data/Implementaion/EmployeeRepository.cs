
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.Contracts.DataContext;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.Data.Implementaion
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly EmployeeManagementContext _ctx;

        public EmployeeRepository(EmployeeManagementContext ctx)
            : base(ctx)
        {
        }
    }
}
