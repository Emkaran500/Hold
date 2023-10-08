using Hold.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hold.HoldDbContexts;

public class HoldDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        try
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=HoldDb;User Id=admin;Password=admin;TrustServerCertificate=True;");
        }
        catch (Exception)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=HoldDb;TrustServerCertificate=True;");
        }
    }
}
