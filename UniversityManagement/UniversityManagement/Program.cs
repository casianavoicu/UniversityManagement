using Neo4j.Driver;
using UniversityManagement;

var builder = WebApplication.CreateBuilder(args);

var settings = builder.Configuration.GetSection("DatabaseConnection");

builder.Services.AddSingleton(GraphDatabase.Driver(settings.GetValue<string>("ConnectionString"),
    AuthTokens.Basic(settings.GetValue<string>("UserName"), settings.GetValue<string>("UserPassword"))));
builder.Services.AddServices();
var app = builder.Build();


app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();
