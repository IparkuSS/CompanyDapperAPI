using CompanyDapperAPI.DAL;
using CompanyDapperAPI.DAL.Repository;
using CompanyDapperAPI.DAL.Repository.Contracts;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddSingleton<CompanyContext>();


builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddControllers();

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
