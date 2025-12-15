using ECommerce.Web.CommonHelper;
using ECommerce.Web.DataAcessLayer.Interface;
using ECommerce.Web.DataAcessLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// ================== SERVICES ==================

// Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

// 🔥 CORS (Build se pehle)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Helper
Helper.Init(builder.Configuration);

// Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// DI
builder.Services.AddScoped<IDalUser, DalUser>();
builder.Services.AddScoped<IDalCetagory, DalCetagory>();
builder.Services.AddScoped<IDALUserManager, DALUserManager>();

// ================== BUILD ==================
var app = builder.Build();

// ================== MIDDLEWARE ==================

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// 🔥 UseCors → Authorization se pehle
app.UseCors("AllowReactApp");

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
