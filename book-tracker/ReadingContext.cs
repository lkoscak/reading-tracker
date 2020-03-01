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

       
    }
}
