
using Microsoft.EntityFrameworkCore;
using StudentSchedule.API.Data;
using StudentSchedule.API.Services;
using StudentSchedule.API.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseInMemoryDatabase("StudentSchedule");
});

builder.Services.AddScoped<ISemesterService, SemesterService>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddScoped<IServiceGatherer, ServiceGatherer>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.UseExceptionHandler("/error");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();