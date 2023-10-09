﻿using Hold.Data.Configurations;
using Hold.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Hold.Data;

public class HoldDbContext : DbContext
{
    public DbSet<Country> Countries { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        try
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=HoldDb;TrustServerCertificate=True;Integrated Security=SSPI;");
        }
        catch (Exception)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=HoldDb;User Id=myUsername;Password=myPassword;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}