using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Models
{
    
    public class RatingTableModel
    {
        public string studentName { get; set; }
        public Dictionary<int, string> gradesDate { get; set; }
        public string courseName { get; set; }
    }
}
