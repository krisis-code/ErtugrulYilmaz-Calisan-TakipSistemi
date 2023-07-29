using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.VModels
{
    public class EmployeeLeaveRequestVM :BaseVM
    {
        //------------------------------------------------------------//

        //TODO:Talepte bulununan kullanıcı bilgileri
        public string RequestingEmployeeId { get; set; }
       
        public EmployeeVM RequestingEmployee { get; set; }

        //TODO:Onaylayan bulununan kullanıcı bilgileri
        public string ApprovedEmployeeId { get; set; }
       
        public EmployeeVM ApprovedEmployee { get; set; }
        public int EmployeeLeaveTypeId { get; set; }
      
        public EmployeeLeaveTypeVM EmployeeLeaveType { get; set; }

        //------------------------------------------------------------//


        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime DateRequest { get; set; }
        [Display(Name ="Talep açıklama")]
        [MaxLength(300,ErrorMessage ="300 karakterden fazla değer girilemez")]
        public string RequestComment { get; set; }

        public bool? Approved { get; set; }

        public bool Cancelled { get; set; }
    }
}
