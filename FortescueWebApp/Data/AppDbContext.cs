using Microsoft.EntityFrameworkCore;
using FortescueWebApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }
}