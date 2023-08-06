using CalisanTakipSistemi.Data.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.DbModels
{
    public class EmployeeLeaveRequest : BaseEntity
    {
        //------------------------------------------------------------//

        //TODO:Talepte bulununan kullanıcı bilgileri
        public string RequestingEmployeeId { get; set; }
        [ForeignKey("RequestingEmployeeId")]
        public Employee  RequestingEmployee { get; set; }

        //TODO:Onaylayan bulununan kullanıcı bilgileri
        public string ApprovedEmployeeId { get; set; }
        [ForeignKey("ApprovedEmployeeId")]
        public Employee ApprovedEmployee { get; set; }
        public int EmployeeLeaveTypeId { get; set; }
        [ForeignKey("EmployeeLeaveTypeId")]
        public EmployeeLeaveType EmployeeLeaveType { get; set; }

        //------------------------------------------------------------//

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DateRequest { get; set; }

        public string RequestComment { get; set; }

        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }
		public bool IsActive { get; set; }
	}
}
