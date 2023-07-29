using AutoMapper;
using EmployeeManagement.BusinesEngine.Contracts;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.ResultModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.Contracts;
using EmployeeManagement.Data.DbModels;

namespace EmployeeManagement.BusinesEngine.Implementaion
{
    public class EmployeeLeaveTypeBusinessEngine : IEmployeeLeaveTypeBusinessEngine
    {

        #region Variables
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }
        #endregion

        #region CustomMethods
        public Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeTypes()
        {
            var data = _unitOfWork.employeeLeaveType.GetAll().ToList();
            #region BirinciYöntem
            //Birinci Yöntem
            //if (data != null)
            //{
            //    List<EmployeeLeaveType> returnData = new List<EmployeeLeaveType>();
            //    foreach (var item in data)
            //    {
            //        returnData.Add(new EmployeeLeaveType()
            //        {
            //            Id = item.Id,
            //            DateCreated = item.DateCreated,
            //            DefaultDays = item.DefaultDays,
            //            Name = item.Name,
            //        });
            //    }
            //    return new Result<List<EmployeeLeaveType>>(true, ResultConstant.RecordFound, returnData);
            //}
            //else
            //    return new Result<List<EmployeeLeaveType>>(false,ResultConstant.RecordNotFound); 
            #endregion

            #region İkinciYöntem
            var leaveTypes = _mapper.Map<List<EmployeeLeaveType>, List<EmployeeLeaveTypeVM>>(data);
            return new Result<List<EmployeeLeaveTypeVM>>(true, ResultConstant.RecordFound, leaveTypes); 
            #endregion
        }



        #endregion
    }
}
