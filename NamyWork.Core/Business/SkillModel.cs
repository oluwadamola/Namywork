using NamyWork.Data.Entities;

namespace NamyWork.Core.Business
{
    public class SkillModel : Model
    {
        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public SkillModel()
        {

        }
        public SkillModel(Skill skill)
        {
            this.Assign(skill);
        }
    }
}
