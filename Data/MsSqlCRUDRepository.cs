using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Data
{
    public class MsSqlCRUDRepository : ICRUDRepository
    {
        private readonly ApplicationDbContext _context;

        public MsSqlCRUDRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Courses> Courses => _context.Courses;

        public IQueryable<CourseBuyingModel> CourseBuying => _context.CourseBuying;

        public IQueryable<Students> Students => _context.Students;

        public IQueryable<StudentsCourses> StudentsCourses => _context.StudentsCourses;

        public IQueryable<StudentsGrades> StudentsGrades => _context.StudentsGrades;

        public IQueryable<StudentsHomework> StudentsHomework => _context.StudentsHomework;

        public IQueryable<CourseVideos> CourseVideos => _context.CourseVideos;

        public void Delete(CourseBuyingModel buyer)
        {
            _context.CourseBuying.Remove(buyer);
            _context.SaveChanges();
        }

        public void Delete(Courses courses)
        {
            _context.Courses.Remove(courses);
            _context.SaveChanges();
        }

        public void Delete(Students Students)
        {
            _context.Students.Remove(Students);
            _context.SaveChanges();
        }

        public void Delete(StudentsCourses StudentsCourses)
        {
            _context.StudentsCourses.Remove(StudentsCourses);
            _context.SaveChanges();
        }

        public void Delete(StudentsGrades StudentsGrades)
        {
            _context.StudentsGrades.Remove(StudentsGrades);
            _context.SaveChanges();
        }

        public void Delete(StudentsHomework StudentsHomework)
        {
            _context.StudentsHomework.Remove(StudentsHomework);
            _context.SaveChanges();
        }

        public void Delete(CourseVideos CourseVideos)
        {
            _context.CourseVideos.Remove(CourseVideos);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Courses courses)
        {
            _context.Update(courses);
            _context.SaveChanges();
        }

        public void Update(Students Students)
        {
            _context.Update(Students);
            _context.SaveChanges();
        }

        public void Update(StudentsCourses StudentsCourses)
        {
            _context.Update(StudentsCourses);
            _context.SaveChanges();
        }

        public void Update(StudentsGrades StudentsGrades)
        {
            _context.Update(StudentsGrades);
            _context.SaveChanges();
        }

        public void Update(StudentsHomework StudentsHomework)
        {
            _context.Update(StudentsHomework);
            _context.SaveChanges();
        }

        public void Update(CourseVideos CourseVideos)
        {
            _context.Update(CourseVideos);
            _context.SaveChanges();
        }
    }
}
