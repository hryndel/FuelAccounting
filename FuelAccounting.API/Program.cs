using FuelAccounting.API.Infrastructures;
using FuelAccounting.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.GetAuthentication();

builder.Services.AddControllers(x =>
{
    x.Filters.Add<FuelAccountingExceptionFiltr>();
}).AddControllersAsServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.GetSwaggerDocument();
builder.Services.AddDependencies();

var conString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextFactory<FuelAccountingContext>(options => options.UseSqlServer(conString), ServiceLifetime.Scoped);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.GetSwaggerDocumnetUI();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();