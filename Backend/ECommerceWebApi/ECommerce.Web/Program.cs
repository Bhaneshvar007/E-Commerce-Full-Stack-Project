using ECommerce.Common.DB;
using ECommerce.Common.Helpers;
using ECommerce.Common.Repository.Interface;
using ECommerce.Common.Repository.Service;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.DataAcessLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddScoped<IHelper, Helper>();
builder.Services.AddScoped<IAppDbContext, AppDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IDalUser, DalUser>();
builder.Services.AddScoped<IDalCetagory, DalCetagory>();

// read connection string
var conn = builder.Configuration.GetConnectionString("DefaultConnection");


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
