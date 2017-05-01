namespace NamyWork.Data.Entities
{
    public class UserRating
    {
        public int UserRatingId { get; set; }
        public int UserId { get; set; }
        public int RatingId { get; set; }
        public virtual User User { get; set; }
        public virtual Rating Rating { get; set; }
    }
}