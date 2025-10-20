using Error_Tracker_API.v1.Context;
using Error_Tracker_API.v1.Service.Implementation;
using Error_Tracker_API.v1.Service.Interface;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .CreateLogger();

//Services
builder.Host.UseSerilog();
builder.Services.AddControllers();
builder.Services.AddDbContext<ErrorDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IErrorLogService, ErrorLogService>();


#if DEBUG
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endif

var app = builder.Build();

#if DEBUG
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Error Tracker Demo API v1");
    options.RoutePrefix = string.Empty;
});
#endif

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ErrorDbContext>();
    db.Database.EnsureCreated(); // Creates SQLite DB if it doesn't exist
}

try
{
    Log.Information("Starting Error Tracker Demo API...");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application failed to start correctly");
}
finally
{
    Log.CloseAndFlush();
}