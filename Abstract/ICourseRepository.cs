using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Abstract
{
    public interface ICourseRepository
    {
        public IQueryable<Courses> Courses { get;}
        public IQueryable<Students> Students { get; }
        public IQueryable<StudentsCourses> StudentsCourses { get; }
        public IQueryable<StudentsGrades> StudentsGrades { get; }
        public IQueryable<StudentsHomework> StudentsHomework { get; }
        public IQueryable<CourseVideos> CourseVideos { get; }
        public IQueryable<CourseBuyingModel> CourseBuying { get; }
    }
}
