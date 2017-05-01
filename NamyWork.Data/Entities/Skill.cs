namespace NamyWork.Data.Entities
{
    public class Skill
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }

    }
    public enum AppSkills
    {
        Android_Developers,
        AngularJS_Developers,
        CDevelopers,
        Copywriters,
        Customer_Service_Representatives,
        Data_Entry_Specialists,
        Email_Marketing_Consultants,
        Excel_Experts
    }
}
