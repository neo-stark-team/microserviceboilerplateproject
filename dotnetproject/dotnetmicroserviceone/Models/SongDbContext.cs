using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnetmicroserviceone.Models;

public class SongDbContext : DbContext
{
    public SongDbContext()
    {
    }

    public SongDbContext(DbContextOptions<SongDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Song> Songs { get; set; }

}

