using NamyWork.Data.Entities;
using System;

namespace NamyWork.Core.Business
{
    public class NotificationModel : Model
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }
        public int UserId { get; set; }
        public virtual UserModel UserModel { get; set; }

        public NotificationModel()
        {

        }
        public NotificationModel(Notification notification)
        {
            this.Assign(notification);
        }
    }
}
