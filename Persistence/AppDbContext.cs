using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    // 在数据库上下文中，创建数据库集，然后指定实体类
    public required DbSet<Activity> Activities { get; set; }
}
