using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WFM_Trail_Api.Abstrations;
using WFM_Trail_Api.Data;
using WFM_Trail_Api.Models;

namespace WFM_Trail_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly WfmTrailContext _context;
        private readonly IEmployee _employee;
        public EmployeesController(WfmTrailContext context,IEmployee employee)
        {
            _context = context;
            _employee = employee;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
                //if (_context.Employees == null)
                //    return StatusCode(StatusCodes.Status404NotFound, new
                //    {
                //        responceMessage = "Employee Table is Empty"
                //    });
                //var empDetails = await _context.Employees.Include(e => e.SkillMaps).ThenInclude(s => s.Skills).ToListAsync();
                //return new OkObjectResult(empDetails);
                var employeeDetails = await _employee.GetAllEmployees();
                return Ok(employeeDetails);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeDetailsById(int employeeId)
        {
            if (employeeId == 0 || employeeId < 0)
            {
                return BadRequest("We don't process Zero/Negative input values..!");
            }
            try
            {
                //var empDetail = await _context.Employees.Include(e => e.SkillMaps).ThenInclude(s => s.Skills).SingleOrDefaultAsync(emp => emp.EmployeeId == employeeId);
                //if (empDetail == null)
                //    return StatusCode(StatusCodes.Status404NotFound, new { responseMessage = "Given Employee Id Details Not Found" });
                //return empDetail;
                var empDetail = await _employee.GetEmployeeDetailsById(employeeId);
                if (empDetail == null)
                    return StatusCode(StatusCodes.Status404NotFound, new { responseMessage = "Given Employee Id Details Not Found" });
                return Ok(empDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpGet("EmployeeDetailbyId")]
        public async Task<ActionResult<Employee>> EmployeeDetailbyId([FromQuery] int employeeId)
        {
            if (employeeId == 0 || employeeId < 0)
            {
                return BadRequest("We don't process Zero/Negative input values..!");
            }
            try
            {
                //var empDetail = await _context.Employees.Include(e => e.SkillMaps).ThenInclude(s => s.Skills).SingleOrDefaultAsync(emp => emp.EmployeeId == employeeId);
                //if (empDetail == null)
                //    return StatusCode(StatusCodes.Status404NotFound, new { responseMessage = "Given Employee Id Details Not Found" });
                //return empDetail;
                var empDetail = await _employee.GetEmployeeDetailsById(employeeId);
                if (empDetail == null)
                    return StatusCode(StatusCodes.Status404NotFound, new { responseMessage = "Given Employee Id Details Not Found" });
                return Ok(empDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { responseMessage = ex.Message });
            }
        }
    }
}
