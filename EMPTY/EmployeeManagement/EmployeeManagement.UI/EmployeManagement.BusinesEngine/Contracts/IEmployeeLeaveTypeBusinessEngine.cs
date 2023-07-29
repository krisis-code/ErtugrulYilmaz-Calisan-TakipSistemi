using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.BusinesEngine.Contracts
{
    public interface IEmployeeLeaveTypeBusinessEngine
    {
        Result<List<EmployeeLeaveType>> GetAllEmployeeTypes();
    }
}
