using Zoo.Domain;
using Zoo.Infrastructure;
using Zoo.App;

var builder = WebApplication.CreateBuilder(args);


// ServiceCollectionExtensions.AddDomain(builder.Services);
builder.Services.AddDomain();
builder.Services.AddInfrastructure();
builder.Services.AddApp();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// app.MapGet("/", () => "Hello World!");

app.Run();
public partial class Program { }
