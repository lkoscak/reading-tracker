using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace book_tracker.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int Score { get; set; }
        public String Review {get;set;}
        public DateTime DateOfReview { get; set; }
        
    }
}
