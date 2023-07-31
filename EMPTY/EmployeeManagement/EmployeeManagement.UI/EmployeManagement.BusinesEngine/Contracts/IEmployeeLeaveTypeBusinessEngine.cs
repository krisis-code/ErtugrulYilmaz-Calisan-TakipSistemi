using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.BusinesEngine.Contracts
{
    public interface IEmployeeLeaveTypeBusinessEngine
    {
        Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeTypes();
		/// <summary>
		/// New Employee Leave Type Create Method
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		Result<EmployeeLeaveRequestVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model);


	}
}
