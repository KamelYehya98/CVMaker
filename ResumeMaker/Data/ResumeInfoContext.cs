using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ResumeMaker.Models;

namespace ResumeMaker.Data
{
    public class ResumeInfoContext : DbContext
    {
        public ResumeInfoContext (DbContextOptions<ResumeInfoContext> options)
            : base(options)
        {
        }

        public DbSet<ResumeInfo> ResumeInfos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Skill> Skills { get; set; }
    }
}
