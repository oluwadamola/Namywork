using NamyWork.Data.Entities;
using System;
using System.Data.Entity.Migrations;
using System.Linq;
using static NamyWork.Data.Entities.Role;

namespace NamyWork.Data.Migrations
{
    public class SeedData
    {
        public static void SeedRoles(DataEntities context)
        {
            context.Roles.AddOrUpdate(r => r.RoleName,

                new Role()
                {
                    RoleName = AppRole.SystemAdministrator.ToString(),
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now
                },
                new Role()
                {
                    RoleName = AppRole.User.ToString(),
                    CreatedBy = 1,
                    CreatedOn = DateTime.Now
                },
                new Role()
                {
                    RoleName = AppRole.Freelancer.ToString(), CreatedBy = 1, CreatedOn = DateTime.Now
                });
        }


        public static void seedAdminUser(DataEntities context)
        {
            var users = new[] {
             new User() {  Email = "admin@gmail.com",  Password = "password", CreatedBy = 1, CreatedOn = DateTime.Now }
            };

            context.Users.AddOrUpdate(u => u.Email, users);


            var profiles = new[] {
                    new Profile() { LastName = "admin", FirstName = "admin", Gender = "Male", ImageUrl = "", PhoneNumber = "08067356779", Title = "Mr" }
            };
            context.Profiles.AddOrUpdate(p => p.PhoneNumber, profiles);
            context.SaveChanges();


            var roles = new[] {
             new Role() { RoleName = AppRole.SystemAdministrator.ToString() }
            };

            context.Roles.AddOrUpdate(r => r.RoleName, roles);
            

            var userroles = (from u in users
                            from r in roles
                            select new { user = u, role = r})
                            .Select(ur => new UserRole() {
                                UserId = ur.user.UserId,
                                RoleId = ur.role.RoleId
                            }).ToArray();
            context.UserRoles.AddOrUpdate(ur => new { ur.UserId, ur.RoleId }, userroles);
            context.SaveChanges();
        }

        public static void SeedSkills(DataEntities context)
        {
            context.Skills.AddOrUpdate(s => s.SkillName,

                new Skill() { SkillName = DomainConstants.Android_Developers },
                new Skill() { SkillName = DomainConstants.AngularJS_Developers },
                new Skill() { SkillName = DomainConstants.CDevelopers },
                new Skill() { SkillName = DomainConstants.Copywriters.ToString() },
                new Skill() { SkillName = DomainConstants.Customer_Service_Representatives },
                new Skill() { SkillName = DomainConstants.Data_Entry_Specialists },
                new Skill() { SkillName = DomainConstants.Email_Marketing_Consultants},
                new Skill() { SkillName = DomainConstants.Excel_Experts.ToString() }

                );
        }

        public static void SeedCategories(DataEntities context)
        {
            context.Categories.AddOrUpdate(c => c.CategoryName,

                new Category() { CategoryName = DomainConstants.Accounting_and_consultants },
                new Category() { CategoryName = DomainConstants.customer_ServiceAgents },
                new Category() { CategoryName = DomainConstants.Designers_and_creatives },
                new Category() { CategoryName = DomainConstants.mobile_developers },
                new Category() { CategoryName = DomainConstants.sales_and_marketing },
                new Category() { CategoryName = DomainConstants.Virtual_Assistants},
                new Category() { CategoryName = DomainConstants.Web_Developers},
                new Category() { CategoryName = DomainConstants.writers}
                );
        }

        public static void SeedCity(DataEntities context)
        {
            context.Cities.AddOrUpdate(l => l.CityName,


                   new City() { CityName = DomainConstants.Abuja },
                   new City() { CityName = DomainConstants.Lagos },
                   new City() { CityName = DomainConstants.Ibadan },
                   new City() { CityName = DomainConstants.Ilorin },
                   new City() { CityName = DomainConstants.Porthcourt }
                   );
       } 
     } 
}
