using CompanyDapperAPI.DAL;
using CompanyDapperAPI.DAL.Repository;
using CompanyDapperAPI.DAL.Repository.Contracts;
using CompanyDapperAPI.GlobalErrorHandling;
using Logger;
using Logger.Contracts;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddSingleton<CompanyContext>();


builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddControllers();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
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
var resolvedLoggerManager = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(resolvedLoggerManager);
/*app.ConfigureExceptionHandler(logger);*/
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
