using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Domains
{
    
    public class StudentsCourses
    {
        public int Id { get; set; }
        public int courseId { get; set; }
        public int studentId { get; set; }
    }
}
