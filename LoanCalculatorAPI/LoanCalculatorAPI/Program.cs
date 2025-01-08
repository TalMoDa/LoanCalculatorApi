using LoanCalculatorAPI.Build.DependencyInjection;
using LoanCalculatorAPI.Build.Logger;
using LoanCalculatorAPI.Build.RequestPipeline;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSettings();
builder.Services.AddDbContext();
builder.Services.AddAppMediatR();
builder.Services.AddServices();
builder.Host.UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });
builder.Services.UseProblemDetails();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseCors(x => { x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(_ => true).AllowCredentials(); });
app.ConfigureSerilogLogger();

app.UseGlobalErrorHandling();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();