using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Models
{
    
    [NotMapped]
    public class HomeworkModel
    {
        [Display(Name = "Имя студнета")]
        public string studentName { get; set; }
        public string filePath { get; set; }
        [Display(Name = "Название курса")]
        public string courseName { get; set; }
        [Display(Name = "Оценка")]
        public int Mark { get; set; }
    }
}
