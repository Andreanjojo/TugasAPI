using SimpleRESTApi.Data;
using SimpleRESTApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IInstructor, InstructorDal>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("api/v1/instructor",(IInstructor instructorData) =>
{
    var instructors = instructorData.GetInstructors();
    return instructors;
});

app.MapGet("api/v1/instructor/{id}",(IInstructor instructorData, int id) =>
{
    var instructor = instructorData.GetInstructorById(id);
    return instructor;
});
app.MapPost("api/v1/instructor",(IInstructor instructorData, Instructor instructor) =>
{
    var newInstructor = instructorData.addInstructor(instructor);
    return newInstructor;
});
app.MapDelete("api/v1/instructor/{id}",(IInstructor instructorData, int id) =>
{
    instructorData.deleteInstructor(id);
    return Results.NoContent();
});
app.MapPut("api/v1/instructor",(IInstructor instructorData, Instructor instructor) =>
{
    var updatedInstructor = instructorData.updateInstructor(instructor);
    return updatedInstructor;
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
