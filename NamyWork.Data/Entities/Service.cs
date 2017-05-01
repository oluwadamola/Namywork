using System;

namespace NamyWork.Data.Entities
{
    public class Service : BaseEntity
    {
        public int ServiceId { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public string Instruction { get; set; }
        public double BudgetFrom { get; set; }

        public double BudgetTo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte[] ImageUrl { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public virtual Category Category { get; set; }
        public virtual City City { get; set; }

    }
}
