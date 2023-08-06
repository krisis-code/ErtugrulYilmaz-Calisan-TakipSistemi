using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Common.VModels
{
    public class EmployeeLeaveTypeVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        public int DefaultDays { get;  set; }
        public DateTime DateCreated { get;  set; }
        public Boolean IsActive { get; set; }
        //MVVM Create EmployeeType
        public void SetEmployeeType(string name)
        {
              this.Name = name;
        }
    }
}
