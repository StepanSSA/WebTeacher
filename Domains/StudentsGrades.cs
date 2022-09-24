using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Domains
{
    
    public class StudentsGrades
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        public int grades { get; set; }
        public int courseId{ get; set; }
        public DateTime date { get; set; }
        public int homeworkId { get; set; }
    }
}
