using System;

namespace NamyWork.Data.Entities
{
    public class BaseEntity 
    {
        public DateTime CreatedOn { get; set; }

        public long CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }

        public BaseEntity()
        {
            CreatedOn = DateTime.Today;
        }
    }
}
