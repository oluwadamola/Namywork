using System;

namespace NamyWork.Data.Entities
{
    public class Notification : BaseEntity
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
