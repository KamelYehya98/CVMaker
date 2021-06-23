using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ResumeMaker.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Email is required")]
        [Display(Name = "jean.kristen20@gmail.com")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password should be at least 8 characters")]
        [Display(Name = "Password")]
        public string PasswordConfirm { get; set; }

        public List<ResumeInfo> Resumes { get; set; }
    }
}
