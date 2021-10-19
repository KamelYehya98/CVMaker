using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ResumeMaker.Models
{
    public class UnRegisteredResume
    {
        [Key]
        public int UnregisteredID { get; set; }
        public int ResumeInfoID { get; set; }

        public UnRegisteredResume(int ResumeInfoID)
        {
            this.ResumeInfoID = ResumeInfoID;
        }
    }
}
