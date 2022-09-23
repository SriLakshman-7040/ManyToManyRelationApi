using Microsoft.EntityFrameworkCore;
using WFM_Trail_Api.Models;


namespace WFM_Trail_Api.Data
{
    public class WfmTrailContext : DbContext
    {
        public WfmTrailContext(DbContextOptions<WfmTrailContext> options) : base(options)
        {
                
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           

            modelBuilder.Entity<SkillMap>()
              .HasOne<Employee>(sc => sc.Employees)
              .WithMany(s => s.SkillMaps)
              .HasForeignKey(sc => sc.EmployeeId);

            modelBuilder.Entity<SkillMap>()
                .HasOne<Skills>(sc => sc.Skills)
                .WithMany(s => s.SkillMaps)
                .HasForeignKey(sc => sc.SkillId);
            modelBuilder.Entity<SkillMap>().HasKey(sm => new { sm.EmployeeId, sm.SkillId });
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<SkillMap> SkillMaps { get; set; }
        public DbSet<WFM_Trail_Api.Models.EmployeesWithSkills> EmployeesWithSkills { get; set; }
    }
}
