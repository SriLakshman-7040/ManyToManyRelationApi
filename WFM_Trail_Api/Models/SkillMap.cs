using System.Text.Json.Serialization;

namespace WFM_Trail_Api.Models
{
    public class SkillMap
    {
        public int EmployeeId { get; set; }
        [JsonIgnore]
        public Employee Employees { get; set; }
        public int SkillId { get; set; }
        [JsonIgnore]
        public Skills Skills { get; set; }
    }
}
