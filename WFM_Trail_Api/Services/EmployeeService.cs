using Microsoft.EntityFrameworkCore;
using WFM_Trail_Api.Abstrations;
using WFM_Trail_Api.Data;
using WFM_Trail_Api.Models;

namespace WFM_Trail_Api.Services
{
    public class EmployeeService : IEmployee
    {
        private readonly WfmTrailContext _context;
        public EmployeeService(WfmTrailContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<EmployeesWithSkills>> GetAllEmployees()
        {
            var employeeDetails = await _context.Employees.Include(e => e.SkillMaps).ThenInclude(s =>s.Skills).Select(es => new EmployeesWithSkills
            {
                EmployeeId = es.EmployeeId,
                Name = es.Name,
                Status = es.Status,
                Manager = es.Manager,
                Wfm_Manager = es.Wfm_Manager,
                Email = es.Email,
                LockStatus = es.LockStatus,
                Experience = es.Experience,
                Skills = es.SkillMaps.Select(s => s.Skills.Name).ToList()
            }).ToListAsync();

            return employeeDetails;
        }

        public async Task<EmployeesWithSkills> GetEmployeeDetailsById(int employeeId)
        {
            var employeeDetail = await _context.Employees.Include(e => e.SkillMaps).ThenInclude(s =>s.Skills).Select(es => new EmployeesWithSkills
            {
                EmployeeId = es.EmployeeId,
                Name = es.Name,
                Status = es.Status,
                Manager = es.Manager,
                Wfm_Manager = es.Wfm_Manager,
                Email = es.Email,
                LockStatus = es.LockStatus,
                Experience = es.Experience,
                Skills = es.SkillMaps.Select(s => s.Skills.Name).ToList()
            }).SingleOrDefaultAsync(emp => emp.EmployeeId == employeeId);

            return employeeDetail;
        }
    }
}
