using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BACKEND.Models 
{

    public class Sharewithcontext : DbContext
    {

        public Sharewithcontext(DbContextOptions<Sharewithcontext> options)
            : base(options)
        {
        }

        public DbSet<ContentShare> ContentShare { get; set; }
        // public DbSet<ContentSharetoPost> ContentSharetoPost { get; set; }
        public DbSet<RecentSearches> RecentSearches { get; set; }
        public DbSet<UserContentDetails> UserContentDetails { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; } 
        public DbSet<UserFavourites> UserFavourites { get; set; }
        public DbSet<UserFileDetails> UserFileDetails { get; set; }
        // public DbSet<mytable> mytable { get; set; }
        
    }
}