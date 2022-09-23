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
    public class SkillsController : ControllerBase
    {
        private readonly WfmTrailContext _context;
        private readonly ISkill _skill;
        public SkillsController(WfmTrailContext context, ISkill skill)
        {
            _context = context;
            _skill = skill;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Skills>>> GetAllSkill()
        {
            //if(_context.Skills == null)
            //    return NotFound("Skills Table is Empty..!");
            //return await _context.Skills.Include(s=>s.SkillMaps).ThenInclude(e=>e.Employees).ToListAsync();
            var skillsWithEmployees = await _skill.GetAllSkill();
            return Ok(skillsWithEmployees);
        }

        [HttpGet("{skillID}")]
        public async Task<ActionResult<Skills>> GetSkillbyId(int skillID)
        {
            if (skillID == 0 || skillID < 0)
                return StatusCode(StatusCodes.Status400BadRequest, new { responseMessage = "We don't process Zero/Negative Input Values" });
            try
            {
                //var skilldetail = await _context.Skills.Include(s => s.SkillMaps).ThenInclude(e => e.Employees).SingleOrDefaultAsync(skill => skill.SkillId == skillID);
                //if (skilldetail == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound, new { responseMessage = "Given Skill Id Details Not Found." });
                //}
                //return skilldetail;
                var skillWithEmpById = await _skill.GetSkillbyId(skillID);
                return Ok(skillWithEmpById);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { responseMessage = ex.Message });
            }
        }

        [HttpGet("GetSkillBySkillId")]
        public async Task<ActionResult<Skills>> GetSkillBySkiillId([FromQuery] int skillID)
        {
            if (skillID == 0 || skillID < 0)
                return StatusCode(StatusCodes.Status400BadRequest, new { responseMessage = "We don't process Zero/Negative Input Values" });
            try
            {
                //var skilldetail = await _context.Skills.Include(s => s.SkillMaps).ThenInclude(e => e.Employees).SingleOrDefaultAsync(skill => skill.SkillId == skillID);
                //if (skilldetail == null)
                //{
                //    return StatusCode(StatusCodes.Status404NotFound, new { responseMessage = "Given Skill Id Details Not Found." });
                //}
                //return skilldetail;
                var skillWithEmpById = await _skill.GetSkillbyId(skillID);
                return Ok(skillWithEmpById);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { responseMessage = ex.Message });
            }
        }
    }
}
