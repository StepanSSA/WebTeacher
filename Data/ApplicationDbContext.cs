﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }

        public DbSet<Courses> Courses { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<StudentsCourses> StudentsCourses { get; set; }
        public DbSet<StudentsGrades> StudentsGrades { get; set; }
        public DbSet<StudentsHomework> StudentsHomework { get; set; }
        public DbSet<CourseVideos> CourseVideos { get; set; }
        public DbSet<CourseBuyingModel> CourseBuying { get; set; }
    }
}
