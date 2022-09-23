using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WFM_Trail_Api.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string Wfm_Manager { get; set; }
        public string Email { get; set; }
        public string LockStatus { get; set; }
        public decimal? Experience { get; set; }
        public int? Profile_ID { get; set; }

        public ICollection<SkillMap> SkillMaps { get; set; } = new HashSet<SkillMap>();
        
    }

    public class EmployeesWithSkills
    {
        [Key]
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Manager { get; set; }
        public string Wfm_Manager { get; set; }
        public string Email { get; set; }
        public string LockStatus { get; set; }
        public decimal? Experience { get; set; }
        [NotMapped]
        public List<string> Skills { get; set; }
    }
}
