using Manager;
using Microsoft.Extensions.DependencyInjection;  // Make sure to include this for dependency injection

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the manager for dependency injection without DbContext
builder.Services.AddScoped<IAttendanceManager, AttendanceManager>();  // Register your manager

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
