using WFM_Trail_Api.Models;

namespace WFM_Trail_Api.Abstrations
{
    public interface ISkill
    {
        Task<IEnumerable<Skillswithemployees>> GetAllSkill();
        public Task<Skillswithemployees> GetSkillbyId(int skillID);
    }
}
