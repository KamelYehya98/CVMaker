using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ResumeMaker.Models
{
    public class ResumeInfo
    {

        [Key]
        public int ResumeInfoID { get; set; }

        [Required(ErrorMessage = "First name is Required")]
        [MinLength(3, ErrorMessage ="Name should contain at least 3 characters.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is Required")]
        [MinLength(3, ErrorMessage = "Name should contain at least 3 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Profession is Required")]
        public string Profession { get; set; }

        [Required(ErrorMessage = "We really insist you tell us a bit about yourself")]
        public string AboutMe { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is Required")]
        [RegularExpression(@"^([\+]?(?:00)?[0-9]{1,3}[\s.-]?[0-9]{1,12})([\s.-]?[0-9]{1,4}?)$", ErrorMessage = "Invalid Phone Format")] 
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }

        
        public string Image { get; set; }
        [RegularExpression(@"http(s) ?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Invalid URL Format")]
        public string GitHub { get; set; }

        [RegularExpression(@"http(s) ?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Invalid URL Format")]
        public string LinkedIn { get; set; }

        [RegularExpression(@"http(s) ?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Invalid URL Format")]
        public string Facebook { get; set; }

        [RegularExpression(@"http(s) ?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Invalid URL Format")]
        public string Twitter { get; set; }

        [RegularExpression(@"http(s) ?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?", ErrorMessage = "Invalid URL Format")]
        public string Instagram { get; set; }

        public string Reference { get; set; }

        public List<Skill> Skills { get; set; }
        public List<Language> Languages { get; set; }
        public List<Experience> Experiences { get; set; }
        public int UserID { get; set; }

        public List<Language> GetLanguages()
        {
            if (Languages == null)
                Languages = new List<Language>();
            return Languages;
        }

        public List<Skill> GetSkills()
        {
            if (Skills == null)
                Skills = new List<Skill>();
            return Skills;
        }
        public List<Experience> GetExperiences()
        {
            if (Experiences == null)
                Experiences = new List<Experience>();
            return Experiences;
        }
    }
}
