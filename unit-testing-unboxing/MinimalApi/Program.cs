
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/api/version", () => "0.0.3" );

app.Run();

// you need to have a public class Program to being able to execute tests
public partial class Program {}