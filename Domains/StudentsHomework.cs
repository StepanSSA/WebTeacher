using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Domains
{
    
    public class StudentsHomework
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        public string filePath { get; set; }
        public int courseId { get; set; }
        public int videoId { get; set; }
    }
}
