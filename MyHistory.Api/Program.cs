using MyHistory.Api.Middleware;
using MyHistory.Application;
using MyHistory.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{

    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplication();
    builder.Services.AddControllers();

}

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.MapControllers();
app.Run();
