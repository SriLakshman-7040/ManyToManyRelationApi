using WFM_Trail_Api.Models;

namespace WFM_Trail_Api.Abstrations
{
    public interface IEmployee
    {
        Task<IEnumerable<EmployeesWithSkills>> GetAllEmployees();
        Task<EmployeesWithSkills> GetEmployeeDetailsById(int employeeId);
    }
}
