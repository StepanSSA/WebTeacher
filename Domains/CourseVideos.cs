using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Domains
{
    
    public class CourseVideos
    {
        public int id { get; set; }
        public int courseId { get; set; }
        [Display(Name = "Номер урока")]
        public int lessonNumber { get; set; }
        [Display(Name = "Ссылка на видео")]
        public string videoPath { get; set; }
        [Display(Name = "Описание")]
        public string description { get; set; }
        [Display(Name = "Название")]
        public string videoName { get; set; }
    }
}
