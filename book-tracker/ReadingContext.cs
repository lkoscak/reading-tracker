using book_tracker.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_tracker
{
    public class ReadingContext : DbContext
    {
        public ReadingContext(DbContextOptions<ReadingContext> options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Book> Books { get; set; }
       
    }
}
