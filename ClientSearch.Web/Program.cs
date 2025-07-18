using ClientSearch.Data.Entities;
using ClientSearch.Models.Search;
using ClientSearch.Service.Service;
using ClientSearch.Web.Extensions;

// Build a configuration from appsettings.json files and store them in the var
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDBContext(configuration);
builder.Services.AddServices();

var app = builder.Build();

app.Services.CreateDBRuntime();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.MapPost("/clientsSearch", async (ClientSearchParams searchParams, IClientService service) =>
{
    var results = await service.GetFilteredDataAsync(searchParams).ConfigureAwait(false);
    return Results.Ok<IEnumerable<Client>>(results);
});


app.Run();
