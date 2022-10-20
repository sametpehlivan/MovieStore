using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration {get; set;}
    public DbSet<Film> Films {get; set;}
    public DbSet<Category> Categories {get; set;}
    public DbSet<FilmCategory> FilmsCategories {get; set;}
    public DbSet<Employee> Employees {get; set;}
    public DbSet<Actor> Actors {get; set;}
    public DbSet<Director> Directors {get; set;}


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
            // Film
            modelBuilder.Entity<Film>(filmBuilder =>
            {
                filmBuilder.ToTable("Films").HasKey(film => film.Id);
                filmBuilder.Property(film => film.Id).HasColumnName("Id");
            });
            // Category
            modelBuilder.Entity<Category>(categoryBuilder => 
            {
                categoryBuilder.ToTable("Categories").HasKey(category => category.Id);
                categoryBuilder.Property(categ => categ.Id).HasColumnName("Id");
            });
            // Employee
            modelBuilder.Entity<Employee>( employeeBuilder => {
                employeeBuilder.ToTable("Employees").HasKey(employee => employee.Id );
                employeeBuilder.Property(employee => employee.Id).HasColumnName("Id");
            });
            // FilmCategory
            modelBuilder.Entity<FilmCategory>( filmCategBuilder => {
                filmCategBuilder.ToTable("FilmsCategories").HasKey( filmCateg => filmCateg.Id);
                filmCategBuilder.Property(filmCateg => filmCateg.Id).HasColumnName("Id");
               
                filmCategBuilder.HasOne<Film>(filmCateg => filmCateg.Film).WithMany(film => film.FilmsCategories).HasForeignKey(filmCateg => filmCateg.FilmId).OnDelete(DeleteBehavior.Restrict);

                filmCategBuilder.HasOne<Category>(filmCateg => filmCateg.Category).WithMany(categ => categ.FilmsCategories).HasForeignKey(filmCateg => filmCateg.CategoryId).OnDelete(DeleteBehavior.Restrict);
            });
            // EmployeeFilm
             modelBuilder.Entity<FilmEmployee>( filmEmpBuilder => {
                filmEmpBuilder.ToTable("FilmEmployee").HasKey( filmEmp => filmEmp.Id);
                filmEmpBuilder.Property(filmEmp => filmEmp.Id).HasColumnName("Id");
               
                filmEmpBuilder.HasOne<Film>(filmEmp => filmEmp.Film).WithMany(film => film.FilmEmployees).HasForeignKey(filmEmp => filmEmp.FilmId).OnDelete(DeleteBehavior.Restrict);

                filmEmpBuilder.HasOne<Employee>(filmEmp => filmEmp.Employee).WithMany(categ => categ.FilmEmployees).HasForeignKey(filmEmp => filmEmp.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            });
            //todo seed extensions
           
           

           
        }


}