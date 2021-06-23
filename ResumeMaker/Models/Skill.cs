using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ResumeMaker.Models
{
    public class Skill
    {
        [Key]
        public int SkillID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Skill Name")]
        public string Name { get; set; }

        [Required]
        public int Proficiency { get; set; }
        public int ResumeInfoID { get; internal set; }

        public Skill(string Name, int Proficiency)
        {
            this.Name = Name;
            this.Proficiency = Proficiency;
        }
    }
}
