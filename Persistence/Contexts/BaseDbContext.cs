using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration {get; set;}
    public  DbSet<Film> Films {get; set;}
    public BaseDbContext(DbContextOptions options , IConfiguration conf):base(options)
    {
        Configuration = conf;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //todo relations conf
            modelBuilder.Entity<Film>(a =>
            {
                a.ToTable("Film").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
            });


            //todo seed extensions
            Film[] filmSeedDatas = { new(1, "Test 1"), new(2, "Test 2") };
            modelBuilder.Entity<Film>().HasData(filmSeedDatas);

           
        }


}