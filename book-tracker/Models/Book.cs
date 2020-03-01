using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_tracker.Models
{
    public class Book
    {

        public int BookID {get;set;}
        public String Title { get; set; }
        public String Description { get; set; }
        public int NumberOfPages { get; set; }
        public Uri ImageURL { get; set; }
        public Uri BookDepoURL { get; set; }

        public Author Author { get; set; }
        public IEnumerable<Rating> BookRatings { get; set; }
    }
}
