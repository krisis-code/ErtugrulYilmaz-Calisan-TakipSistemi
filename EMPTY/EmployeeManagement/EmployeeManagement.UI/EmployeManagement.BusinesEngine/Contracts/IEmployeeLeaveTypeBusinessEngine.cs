using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.BusinesEngine.Contracts
{
    public interface IEmployeeLeaveTypeBusinessEngine
    {
        Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes();
		/// <summary>
		/// New Employee Leave Type Create Method
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model);

		/// <summary>
		/// Ger Employee leave Type By Id
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveType(int id);

		Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model);

	}
}
