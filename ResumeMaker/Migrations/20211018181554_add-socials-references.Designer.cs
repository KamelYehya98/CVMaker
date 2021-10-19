﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ResumeMaker.Data;

namespace ResumeMaker.Migrations
{
    [DbContext(typeof(ResumeInfoContext))]
    [Migration("20211018181554_add-socials-references")]
    partial class addsocialsreferences
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ResumeMaker.Models.Experience", b =>
                {
                    b.Property<int>("ExperienceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResumeInfoID")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ExperienceID");

                    b.HasIndex("ResumeInfoID");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("ResumeMaker.Models.Language", b =>
                {
                    b.Property<int>("LanguageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Proficiency")
                        .HasColumnType("int");

                    b.Property<int>("ResumeInfoID")
                        .HasColumnType("int");

                    b.HasKey("LanguageID");

                    b.HasIndex("ResumeInfoID");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("ResumeMaker.Models.ResumeInfo", b =>
                {
                    b.Property<int>("ResumeInfoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutMe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GitHub")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profession")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Twitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ResumeInfoID");

                    b.HasIndex("UserID");

                    b.ToTable("ResumeInfos");
                });

            modelBuilder.Entity("ResumeMaker.Models.Skill", b =>
                {
                    b.Property<int>("SkillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Proficiency")
                        .HasColumnType("int");

                    b.Property<int>("ResumeInfoID")
                        .HasColumnType("int");

                    b.HasKey("SkillID");

                    b.HasIndex("ResumeInfoID");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("ResumeMaker.Models.UnRegisteredResume", b =>
                {
                    b.Property<int>("UnregisteredID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ResumeInfoID")
                        .HasColumnType("int");

                    b.HasKey("UnregisteredID");

                    b.ToTable("UnRegisteredResumes");
                });

            modelBuilder.Entity("ResumeMaker.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordConfirm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ResumeMaker.Models.Experience", b =>
                {
                    b.HasOne("ResumeMaker.Models.ResumeInfo", null)
                        .WithMany("Experiences")
                        .HasForeignKey("ResumeInfoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeMaker.Models.Language", b =>
                {
                    b.HasOne("ResumeMaker.Models.ResumeInfo", null)
                        .WithMany("Languages")
                        .HasForeignKey("ResumeInfoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeMaker.Models.ResumeInfo", b =>
                {
                    b.HasOne("ResumeMaker.Models.User", null)
                        .WithMany("Resumes")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeMaker.Models.Skill", b =>
                {
                    b.HasOne("ResumeMaker.Models.ResumeInfo", null)
                        .WithMany("Skills")
                        .HasForeignKey("ResumeInfoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ResumeMaker.Models.ResumeInfo", b =>
                {
                    b.Navigation("Experiences");

                    b.Navigation("Languages");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("ResumeMaker.Models.User", b =>
                {
                    b.Navigation("Resumes");
                });
#pragma warning restore 612, 618
        }
    }
}
