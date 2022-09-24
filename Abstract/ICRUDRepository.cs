using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Abstract
{
    public interface ICRUDRepository : ICourseRepository
    {
        public void Save();
        public void Delete(CourseBuyingModel buyer);
        public void Delete(Courses courses);
        public void Update(Courses courses);

        public void Delete(Students Students);
        public void Update(Students Students);

        public void Delete(StudentsCourses StudentsCourses);
        public void Update(StudentsCourses StudentsCourses);

        public void Delete(StudentsGrades StudentsGrades);
        public void Update(StudentsGrades StudentsGrades);

        public void Delete(StudentsHomework StudentsHomework);
        public void Update(StudentsHomework StudentsHomework);

        public void Delete(CourseVideos CourseVideos);
        public void Update(CourseVideos CourseVideos);
    }
}
