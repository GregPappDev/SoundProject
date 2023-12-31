﻿using Microsoft.EntityFrameworkCore;
using SoundApi.Models;

namespace SoundApi.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext()
        {
            
        }

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<SoundModel> Sounds { get; set; }
    }
}
