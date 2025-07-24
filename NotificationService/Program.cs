using Microsoft.Extensions.DependencyInjection;
using NotificationService.Services.MapperService;
using NotificationService.Services.NotificationService;
using Serilog;
using Vonage.Extensions;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

try
{
    Log.Information("starting server.");
    var builder = WebApplication.CreateBuilder(args);


    // Add services to the container.

    builder.Host.UseSerilog((context, loggerConfiguration) =>
    {
        loggerConfiguration.WriteTo.Console();
        loggerConfiguration.ReadFrom.Configuration(context.Configuration);
    });

    //https://codewithmukesh.com/blog/structured-logging-with-serilog-in-aspnet-core/#serilog-sinks

    builder.Services.AddScoped<ISender, Sender>();
    builder.Services.AddScoped<INotificationService, NotificationService.Services.NotificationService.NotificationService>();
    builder.Services.AddAutoMapper(typeof(ModelProfile));
    builder.Services.AddVonageClientScoped(builder.Configuration);
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

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
}
catch (Exception ex)
{
    Log.Fatal(ex, "server terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}


