using MinimalApi.Interfaces;
using MinimalApi.Models;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);
// interface is agregated using dependency injection
builder.Services.AddScoped<PeopleServiceInterface, PeopleService>();

var app = builder.Build();

app.MapGet( "/", () => "Hello World!" );
app.MapGet( "/api/version", () => "0.0.3" );

// people service
app.MapPost( "/people", (PeopleServiceInterface service, Person person) =>
    !MiniValidator.TryValidate( person, out var errors )
        ? Results.ValidationProblem(errors)
        : Results.Ok( service.Create(person) )
);

app.Run();

// you need to have a public class Program to being able to execute tests
public partial class Program {}