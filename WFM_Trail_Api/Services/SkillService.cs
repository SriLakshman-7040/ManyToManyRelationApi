using Microsoft.EntityFrameworkCore;
using WFM_Trail_Api.Abstrations;
using WFM_Trail_Api.Data;
using WFM_Trail_Api.Models;

namespace WFM_Trail_Api.Services
{
    public class SkillService : ISkill
    {
        private readonly WfmTrailContext _context;
        public SkillService(WfmTrailContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Skillswithemployees>> GetAllSkill()
        {
            var skillWithEmps = await _context.Skills.Include(sm => sm.SkillMaps).ThenInclude(e => e.Employees).Select(se => new Skillswithemployees
            {
                SkillId = se.SkillId,
                Name = se.Name,
                Employees = se.SkillMaps.Select(emp => emp.Employees).ToList()
            }).ToListAsync();

            return skillWithEmps;
        }
        public async Task<Skillswithemployees> GetSkillbyId(int skillID)
        {
            var skillWithEmp = await _context.Skills.Include(sm => sm.SkillMaps).ThenInclude(e =>e.Employees).Select(se => new Skillswithemployees
            {
                SkillId =se.SkillId,
                Name =se.Name,
                Employees = se.SkillMaps.Select(emp => emp.Employees).ToList()
            }).SingleOrDefaultAsync(e => e.SkillId == skillID);
            return skillWithEmp;
        }
    }
}
