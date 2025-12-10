using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// 指定一个“应用程序数据库上下文”服务，
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    // 使用 SQLite 作为数据库提供程序，并从配置中获取连接字符串 DefaultConnection
    opt.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")
    );
});
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
// 跨域：允许任何头、允许任何方法、允许的来源
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:3000","https://localhost:3000"));
app.MapControllers();

app.Run();
