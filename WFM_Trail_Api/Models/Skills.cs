using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WFM_Trail_Api.Models
{
    public class Skills
    {
        [Key]
        public int SkillId { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<SkillMap> SkillMaps { get; set; } = new HashSet<SkillMap>();
    }

    public class Skillswithemployees
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
