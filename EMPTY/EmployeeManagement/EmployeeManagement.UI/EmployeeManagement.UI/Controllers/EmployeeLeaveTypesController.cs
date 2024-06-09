using EmployeeManagement.BusinesEngine.Contracts;
using EmployeeManagement.BusinesEngine.Implementaion;
using EmployeeManagement.Common.ConstantModels;
using EmployeeManagement.Common.VModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.UI.Controllers
{
    [Authorize(Roles =ResultConstant.Admin_Role)]
    public class EmployeeLeaveTypesController : Controller
    {
        private readonly IEmployeeLeaveTypeBusinessEngine _employeeLeaveTypeBusinessEngine;

        public EmployeeLeaveTypesController(IEmployeeLeaveTypeBusinessEngine employeeLeaveTypeBusinessEngine)
        {
            _employeeLeaveTypeBusinessEngine = employeeLeaveTypeBusinessEngine;
        }
        public IActionResult Index()
        {
            var data = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes();
            if (data.IsSucces == true)
            {
                var result = data.Data;
                return View(result);
            }
            return View();
        }
        [HttpGet]
		public IActionResult Create()
		{
			
			return View();
		}
        [HttpPost]
		public IActionResult Create(EmployeeLeaveTypeVM model)
		{
            if (ModelState.IsValid)
            {
                var data = _employeeLeaveTypeBusinessEngine.CreateEmployeeLeaveType(model);
                if (data.IsSucces)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
			}
            else 
                return View(model);
			

			
		}

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id < 0)
                return View();
            var data = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveType(id);
            if (data.IsSucces)
              return View(data.Data);
            return View();

		}
        [ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult Edit(EmployeeLeaveTypeVM model)
		{
			if(ModelState.IsValid) 
            {
            var data = _employeeLeaveTypeBusinessEngine.EditEmployeeLeaveType(model);
                if (data.IsSucces)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
                
            }
			else
				return View(model);

		}

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(new { success = false, message = "Silmek İçin Kayıt Seçiniz" });

            var data = _employeeLeaveTypeBusinessEngine.RemoveEmployeeLeaveType(id);

            if (data.IsSucces)
                return Json(new { success = data.IsSucces, message = data.Message });
            else
                return Json(new { success = data.IsSucces, message = data.Message });

        }
    }
}
