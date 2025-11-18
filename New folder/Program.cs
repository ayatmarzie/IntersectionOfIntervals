using Core.Services;
using Microsoft.EntityFrameworkCore;
using DAL;
using TestEF.ClassLibrary1;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<UniversityDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("WebAPI")  // This line is the fix
    ));

builder.Services.AddScoped<UniversityService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
var services = scope.ServiceProvider;
try
{
var context = services.GetRequiredService<UniversityDbContext>();
DbInitializer.Initialize(context);
}
catch (Exception ex)
{
var logger = services.GetRequiredService<ILogger<Program>>();
logger.LogError(ex, "An error occurred while seeding the database.");
}
}

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapGet("/students", async (UniversityDbContext db) =>
    await db.Students
        .Select(s => new { s.id, s.name })
        .ToListAsync())
   .Produces<List<object>>()  // Fixed: was List<T>
   .WithName("GetStudents");

app.MapGet("/courses", async (UniversityDbContext db) =>
    await db.Courses.Select(c => new { c.id, c.name }).ToListAsync())
   .WithName("GetCourses")
   .Produces<List<object>>();
app.Run();
