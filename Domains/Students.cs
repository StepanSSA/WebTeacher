using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationTeacher.Domains
{
    public class Students
    {
        public int Id { get; set; }
        [Display(Name = "Имя")]
        public string fullName { get; set; }
        [Display(Name = "Возраст")]
        public int age { get; set; }
        [Display(Name = "Пол")]
        public string sex { get; set; }
    }
}
