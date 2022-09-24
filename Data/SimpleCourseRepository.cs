using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Data
{
    public class SimpleCourseRepository : ICourseRepository
    {
        public IQueryable<Courses> Courses =>
            new List<Courses>()
            {
                new Courses()
                {
                    Name = "Beginner",
                    Description = "На этом курсе вы познакомитесь с основами Английского языка",
                    Price = 5000,
                    Size = 10
                },
                new Courses()
                {
                    Name = "Elementary",
                    Description = "На этом курсе вы продолжите изучать основы Английского языка",
                    Price = 7000,
                    Size = 10
                },
                new Courses()
                {
                    Name = "Intermediate",
                    Description = "На этом курсе вы поднимите свои знания языка до уровня Intermediate",
                    Price = 9000,
                    Size = 10
                },
                new Courses()
                {
                    Name = "Upper Intermediate",
                    Description = "На этом курсе вы поднимите свои знания языка до уровня Upper Intermediate",
                    Price = 11000,
                    Size = 10
                },
                new Courses()
                {
                    Name = "Advanced",
                    Description = "На этом курсе вы поднимите свои знания языка до уровня Advanced",
                    Price = 13000,
                    Size = 10
                },
                new Courses()
                {
                    Name = "Proficiency",
                    Description = "На этом курсе вы поднимите свои знания языка до уровня Proficiency",
                    Price = 5000,
                    Size = 10
                },
            }.AsQueryable();

        public IQueryable<CourseBuyingModel> CourseBuying => throw new NotImplementedException();

        public IQueryable<Students> Students => new List<Students>()
        {
            new Students()
            {
                age = 15,
                fullName  = "Вася 1",
                sex = "Мужской"
            },
            new Students()
            {
                age = 15,
                fullName  = "Вася 2",
                sex = "Мужской"
            },
            new Students()
            {
                age = 15,
                fullName  = "Вася 3",
                sex = "Мужской"
            },
            new Students()
            {
                age = 15,
                fullName  = "Вася 4",
                sex = "Мужской"
            }

        }.AsQueryable();

        public IQueryable<StudentsCourses> StudentsCourses => new List<StudentsCourses>()
        {
            new StudentsCourses()
            {
                courseId = 1,
                studentId = 1
            }
        }.AsQueryable();

        public IQueryable<StudentsGrades> StudentsGrades => new List<StudentsGrades>()
        {
                new StudentsGrades()
                {
                    courseId = 1,
                    studentId = 1,
                    date = DateTime.Now,
                    grades = 4,
                    homeworkId = 1
                },
                new StudentsGrades()
                {
                    courseId = 1,
                    studentId = 1,
                    date = DateTime.Today,
                    grades = 4,
                    homeworkId = 2
                },
                new StudentsGrades()
                {
                    courseId = 1,
                    studentId = 1,
                    date = DateTime.Today,
                    grades = 5,
                    homeworkId = 3
                },
                new StudentsGrades()
                {
                    courseId = 1,
                    studentId = 1,
                    date = DateTime.Today,
                    grades = 2,
                    homeworkId = 4
                }
            }.AsQueryable();

        public IQueryable<StudentsHomework> StudentsHomework => throw new NotImplementedException();

        public IQueryable<CourseVideos> CourseVideos => new List<CourseVideos>()
        {
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 1,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Первый урок в цикле",
                    videoName = "1"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 2,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Второй урок в цикле",
                    videoName = "2"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 3,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Третий урок в цикле",
                    videoName = "3"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 4,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Четвёртый урок в цикле",
                    videoName = "4"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 5,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Пятый урок в цикле",
                    videoName = "5"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 6,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Шестой урок в цикле",
                    videoName = "6"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 7,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Седьмой урок в цикле",
                    videoName = "7"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 8,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Восьмой урок в цикле",
                    videoName = "8"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 9,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Девятый урок в цикле",
                    videoName = "9"
                },
                new CourseVideos()
                {
                    courseId = 1,
                    lessonNumber = 10,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Десятый урок в цикле",
                    videoName = "10"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 1,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Первый урок в цикле",
                    videoName = "1"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 2,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Второй урок в цикле",
                    videoName = "2"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 3,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Третий урок в цикле",
                    videoName = "3"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 4,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Четвёртый урок в цикле",
                    videoName = "4"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 5,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Пятый урок в цикле",
                    videoName = "5"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 6,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Шестой урок в цикле",
                    videoName = "6"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 7,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Седьмой урок в цикле",
                    videoName = "7"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 8,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Восьмой урок в цикле",
                    videoName = "8"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 9,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Девятый урок в цикле",
                    videoName = "9"
                },
                new CourseVideos()
                {
                    courseId = 2,
                    lessonNumber = 10,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Десятый урок в цикле",
                    videoName = "10"
                }, 
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 1,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Первый урок в цикле",
                    videoName = "1"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 2,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Второй урок в цикле",
                    videoName = "2"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 3,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Третий урок в цикле",
                    videoName = "3"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 4,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Четвёртый урок в цикле",
                    videoName = "4"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 5,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Пятый урок в цикле",
                    videoName = "5"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 6,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Шестой урок в цикле",
                    videoName = "6"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 7,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Седьмой урок в цикле",
                    videoName = "7"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 8,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Восьмой урок в цикле",
                    videoName = "8"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 9,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Девятый урок в цикле",
                    videoName = "9"
                },
                new CourseVideos()
                {
                    courseId = 0,
                    lessonNumber = 10,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Десятый урок в цикле",
                    videoName = "10"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 1,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Первый урок в цикле",
                    videoName = "1"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 2,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Второй урок в цикле",
                    videoName = "2"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 3,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Третий урок в цикле",
                    videoName = "3"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 4,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Четвёртый урок в цикле",
                    videoName = "4"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 5,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Пятый урок в цикле",
                    videoName = "5"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 6,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Шестой урок в цикле",
                    videoName = "6"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 7,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Седьмой урок в цикле",
                    videoName = "7"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 8,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Восьмой урок в цикле",
                    videoName = "8"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 9,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Девятый урок в цикле",
                    videoName = "9"
                },
                new CourseVideos()
                {
                    courseId = 3,
                    lessonNumber = 10,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Десятый урок в цикле",
                    videoName = "10"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 1,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Первый урок в цикле",
                    videoName = "1"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 2,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Второй урок в цикле",
                    videoName = "2"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 3,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Третий урок в цикле",
                    videoName = "3"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 4,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Четвёртый урок в цикле",
                    videoName = "4"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 5,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Пятый урок в цикле",
                    videoName = "5"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 6,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Шестой урок в цикле",
                    videoName = "6"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 7,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Седьмой урок в цикле",
                    videoName = "7"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 8,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Восьмой урок в цикле",
                    videoName = "8"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 9,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Девятый урок в цикле",
                    videoName = "9"
                },
                new CourseVideos()
                {
                    courseId = 4,
                    lessonNumber = 10,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Десятый урок в цикле",
                    videoName = "10"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 1,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Первый урок в цикле",
                    videoName = "1"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 2,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Второй урок в цикле",
                    videoName = "2"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 3,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Третий урок в цикле",
                    videoName = "3"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 4,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Четвёртый урок в цикле",
                    videoName = "4"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 5,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Пятый урок в цикле",
                    videoName = "5"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 6,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Шестой урок в цикле",
                    videoName = "6"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 7,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Седьмой урок в цикле",
                    videoName = "7"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 8,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Восьмой урок в цикле",
                    videoName = "8"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 9,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Девятый урок в цикле",
                    videoName = "9"
                },
                new CourseVideos()
                {
                    courseId = 5,
                    lessonNumber = 10,
                    videoPath = @"https://www.youtube.com/embed/vyudDK4tGx4",
                    description = "Десятый урок в цикле",
                    videoName = "10"
                }
            }.AsQueryable();
    }
    
}
