using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using dotnetapp.Models;

namespace dotnetapp.Models
{
    public class BookDbContext :DbContext
{
public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     // Configure relationships, constraints, and validations
    //     modelBuilder.Entity<Category>()
    //         .HasMany(r => r.Book)
    //         .WithOne(c => c.Category)
    //         .HasForeignKey(c => c.Id);
    // }
    }
}
