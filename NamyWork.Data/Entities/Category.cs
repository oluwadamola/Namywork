namespace NamyWork.Data.Entities
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

    public enum AppCategory
    {
        Web_Developers,
        Virtual_Assistants,
        mobile_developers,
        customer_ServiceAgents,
        Designers_and_creatives,
        writers,
        sales_and_marketing,
        Accounting_and_consultants

    }
}
