using Microsoft.AspNetCore.Mvc;
using WFM_Trail_Api.Abstrations;

namespace WFM_Trail_Api.Controllers
{
    public class EmployeeMvcController : Controller
    {
        private readonly IEmployee _employee;
        public EmployeeMvcController(IEmployee employee)
        {
            _employee = employee;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ShowAllEmployees()
        {
            try
            {
                var empDetails = await _employee.GetAllEmployees();
                return View(empDetails);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }
    }
}
