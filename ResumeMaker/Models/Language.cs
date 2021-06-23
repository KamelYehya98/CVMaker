using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ResumeMaker.Models
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required]
        public int Proficiency { get; set; }
        public int ResumeInfoID { get; set; }


        public Language(string Name, int Proficiency)
        {
            this.Name = Name;
            this.Proficiency = Proficiency;
        }
    }
}
