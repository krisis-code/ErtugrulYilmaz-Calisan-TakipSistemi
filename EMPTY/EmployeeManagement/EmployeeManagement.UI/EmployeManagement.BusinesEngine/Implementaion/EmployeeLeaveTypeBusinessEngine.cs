using EmployeeManagement.BusinesEngine.Contracts;
using EmployeeManagement.Data.Contracts;

namespace EmployeeManagement.BusinesEngine.Implementaion
{
    public class EmployeeLeaveTypeBusinessEngine : IEmployeeLeaveTypeBusinessEngine
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeLeaveTypeBusinessEngine(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }
    }
}
