using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Domains;

namespace WebApplicationTeacher.Models
{
    
    public class EditCourseModel
    {
        public int id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
        [Display(Name = "Длительность курса")]
        public int Size { get; set; }
        [Display(Name = "Видео уроки")]
        public List<CourseVideos> videos { get; set; }
    }
}
