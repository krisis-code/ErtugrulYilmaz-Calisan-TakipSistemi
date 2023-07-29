using EmployeeManagement.BusinesEngine.Contracts;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;
using System.Collections.Generic;

namespace EmployeeManagement.BusinesEngine.Implementaion
{
    public class EmployeeLeaveTypeBusinessEngine : IEmployeeLeaveTypeBusinessEngine
    {

        #region Variables
        private readonly IUnitOfWork _unitOfWork; 
        #endregion

        #region Constructor
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }
        #endregion

        #region CustomMethods
        public Result<List<EmployeeLeaveType>> GetAllEmployeeTypes()
        {
            var data = _unitOfWork.employeeLeaveType.GetAll().ToList();
            if (data != null)
            {
                List<EmployeeLeaveType> returnData = new List<EmployeeLeaveType>();
                foreach (var item in data)
                {
                    returnData.Add(new EmployeeLeaveType()
                    {
                        Id = item.Id,
                        DateCreated = item.DateCreated,
                        DefaultDays = item.DefaultDays,
                        Name = item.Name,
                    });
                }
                return new Result<List<EmployeeLeaveType>>(true, ResultConstant.RecordFound, returnData);
            }
            else
                return new Result<List<EmployeeLeaveType>>(false,ResultConstant.RecordNotFound);
        } 
        #endregion
    }
}
