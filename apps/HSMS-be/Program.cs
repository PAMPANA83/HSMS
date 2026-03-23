using HSMS.Application.Abstractions;
using HSMS.Application.IRepositories;
using HSMS.Application.IServices;
using HSMS.Application.Mapping;
using HSMS.Application.Services;
using HSMS.Application.UoW;
using HSMS.contracts.Dto;
using HSMS.infrastructure.Persistence;
using HSMS.infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // required for Swagger
builder.Services.AddSwaggerGen();
builder.Services.Configure<SqlServerDto>(
    builder.Configuration.GetSection("SqlServer"));
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<AutoMapping>();
});

#region File objects methods
builder.Services.AddSingleton<Confighelper>();
builder.Services.AddTransient<SqlserverConnHelper>();
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
#endregion
#region Repositories
builder.Services.AddSingleton<CountryMasterIRepositories, CountryMasterRepositories>();
builder.Services.AddSingleton<StateMasterIRepositories, StateMasterRepositories>();
builder.Services.AddSingleton<DistrictMasterIRepositories, DistrictMasterRepositories>();
builder.Services.AddSingleton<CityMasterIRepositories, CityMasterRepositories>();
builder.Services.AddSingleton<AreaMastersIRepositories,AreaMastersRepositories>();
builder.Services.AddSingleton<BranchMastersIRepositories, BranchMastersRepositories>();
builder.Services.AddSingleton<CompanyMastersIRepositories,CompanyMastersRepositories>();
builder.Services.AddSingleton<MainDepartmentMastersIRepositories, MainDepartmentMastersRepositories>();
builder.Services.AddSingleton<DepartmentMastersIRepositories, DepartmentMastersRepositories>();
builder.Services.AddSingleton<DesignationsIRepositories,DesignationsRepositories>();
builder.Services.AddSingleton<QualificationMastersIRepositories,QualificationMastersRepositories>();
#endregion

#region Register Services
builder.Services.AddSingleton<CountryMasterIService, CountryMasterService>();
builder.Services.AddSingleton<StateMasterIService, StateMasterService>();
builder.Services.AddSingleton<DistrictMasterIService, DistrictMasterService>();
builder.Services.AddSingleton<CityMasterIServices,CityMasterServices>();
builder.Services.AddSingleton<AreaMasterIService,AreaMasterService>();
builder.Services.AddSingleton<BranchMasterIService,BranchMasterService>();
builder.Services.AddSingleton<CompanyMasterIService, CompanyMasterService>();
builder.Services.AddSingleton<MainDepartmentIService, MainDepartmentService>();
builder.Services.AddSingleton<QualificationMastersIService,QualificationMastersService>();
builder.Services.AddSingleton<DesignationsIService, DesignationsService>();

#endregion
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Hosptial API", Version = "v1" });
});
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")  // Your React dev server
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials(); // If using auth cookies/JWT
    });
});
var app = builder.Build();
app.UseCors("AllowReactApp");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();     // serve generated Swagger as JSON
    app.UseSwaggerUI(options =>  // Serves Swagger UI at /swagger
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Hospital API v1");
        options.RoutePrefix = "swagger";  // Access at /swagger
    });   // serve Swagger UI
}

app.UseHttpsRedirection();
app.UseRouting();
app.MapControllers();
//app.MapGet("/swagger/index");

app.Run();
