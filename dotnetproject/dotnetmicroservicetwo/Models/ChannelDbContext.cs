using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dotnetmicroservicetwo.Models;

public class ChannelDbContext : DbContext
{

    public ChannelDbContext(DbContextOptions<ChannelDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Channel> Channels { get; set; }
}
