using Microsoft.EntityFrameworkCore;
using WFM_Trail_Api.Abstrations;
using WFM_Trail_Api.Data;
using WFM_Trail_Api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WfmTrailContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmployee, EmployeeService>();
builder.Services.AddScoped<ISkill, SkillService>(); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

//app.MapControllers();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=EmployeeMvc}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
