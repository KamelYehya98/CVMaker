using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResumeMaker.Models;
using ServiceStack;

namespace ResumeMaker.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ResumeInfoContext context)
        {
            if (context.ResumeInfos.Any())
            {
                return;
            }

            //var resumes = new ResumeInfo[]
            //{
            //    new ResumeInfo{FirstName="Kamel", LastName = "Yehya", Profession = "Computer Scientist", Email = "kamel.yehya04@gmail.com",
            //        Address = "Beirut-Lebanon", Image = "", PhoneNumber = "+961 81061889",
            //        User = new User{Email = "kamel.yehya04@gmail.com", Password = "karam1234554321kamel%"} }

            //};
            //var languages = new Language[]
            //{
            //    new Language("English" ,3),
            //    new Language("Arabic", 3)
            //};
            //var skills = new Skill[]
            //{
            //    new Skill("boonga boonga", 3),
            //    new Skill("Piano", 2)
            //};
            //var experiences = new Experience[]
            //{
            //    new Experience("Monke proj", "omae wa mou shindeiru"),
            //    new Experience("Hasagi", "Yume o akiramete shinde kure")
            //};
            //var users = new User[] 
            //{ 
            //    new User{Email="kamel.yehya04@gmail.com", Password="karam12345543221kamel%", , UserID = 1}

            //};



        }
    }
}
