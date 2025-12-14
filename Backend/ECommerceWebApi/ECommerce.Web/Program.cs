
using ECommerce.Web.CommonHelper;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.DataAcessLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

Helper.Init(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});




builder.Services.AddScoped<IDalUser, DalUser>();
builder.Services.AddScoped<IDalCetagory, DalCetagory>();
builder.Services.AddScoped<IDALUserManager, DALUserManager>();

// read connection string
var conn = builder.Configuration.GetConnectionString("DefaultConnection");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSession();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
