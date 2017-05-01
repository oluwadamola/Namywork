using System.Collections.Generic;

namespace NamyWork.Data.Entities
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public string Values { get; set; }
        public ICollection<UserRating> UserRatings { get; set; }
    }
}
