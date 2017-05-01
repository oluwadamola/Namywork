using NamyWork.Data.Entities;
using System;
using System.Collections.Generic;

namespace NamyWork.Core.Business
{
    public class ServiceModel : Model
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
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public UserModel User { get; set; }
        public ICollection<CategoryModel> Categories { get; set; } = new HashSet<CategoryModel>();
        public ICollection<CityModel> Cities { get; set; } = new HashSet<CityModel>();

        public ServiceModel()
        {

        }
        public ServiceModel(Service service)
        {
            this.Assign(service);
        }

        public Service Create()
        {
            return new Service
            {
                 Description = Description,
                 ImageUrl = ImageUrl,
                 Instruction = Instruction,
                 JobTitle = JobTitle,
                 BudgetFrom = BudgetFrom,
                 BudgetTo = BudgetTo,
                 StartDate = StartDate,
                 EndDate = EndDate,
                 UserId = UserId,
                 CategoryId = CategoryId,
                 CityId = CityId                
            };
        }

        public Service Update(Service service)
        {
            Instruction = Instruction;
            BudgetFrom = BudgetFrom;
            BudgetTo = BudgetTo;
            Description = Description;
            JobTitle = JobTitle;
            ImageUrl = ImageUrl;
            UserId = UserId;
            CategoryId = CategoryId;
            CityId = CityId;
            return service;
        }
    }
}
