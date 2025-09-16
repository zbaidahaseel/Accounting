using Accounting_Api.AutoFac;
using Accounting_Business.Mappings;
using Accounting_Business.Persistence.Entities;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.  

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi  
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
 options.UseSqlServer(
      builder.Configuration.GetConnectionString("ConnectionString")
)
);

//builder.Services.AddAutoMapper(typeof(MasterDataMapper).Assembly);


builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(typeof(MasterDataMapper).Assembly);
});
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
  containerBuilder = new AutoFacContainerBuilder(containerBuilder).GetBuilder());

var app = builder.Build();

// Configure the HTTP request pipeline.  
if (app.Environment.IsDevelopment())
{

    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
