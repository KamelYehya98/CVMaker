using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ResumeMaker.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Experience Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(20, ErrorMessage = "Write at least 20 characters")]
        [Display(Name = "Tell us about it....")]
        public string Text { get; set; }
        public int ResumeInfoID { get; internal set; }

        public Experience(string Name, string Text)
        {
            this.Name = Name;
            this.Text = Text;
        }
    }
}
