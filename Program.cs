using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
//Serilog
builder.Host.UseSerilog();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

//Serilog
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

//Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

//Serilog
app.UseSerilogRequestLogging();

Log.Information("Application starting up");
Log.Information("https://localhost:7027");
Log.Information("http://localhost:5027");

try
{
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "The application faild to start correctly");
}
finally
{
    Log.CloseAndFlush();
}





