using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Data;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebApplicationTeacher.Controllers
{
    public class BossController : Controller
    {
        private readonly ICourseRepository _repo;
        private readonly ICRUDRepository _crudRepo;
        private readonly IWebHostEnvironment _appEnvironment;
        public BossController(ICourseRepository repo, ICRUDRepository crudRepo, IWebHostEnvironment appEnvironment)
        {
            _repo = repo;
            _crudRepo = crudRepo;
            _appEnvironment = appEnvironment;
        }

        public IActionResult ListCourse()
        {
            var courses = _repo.Courses.ToList();
            if (courses == null)
                return RedirectToAction("Index", "Home");
            return View(courses);
        }

        public IActionResult CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCourse(Courses course)
        {
            DataHelper.SaveChanges(course);
            var courses = _repo.Courses.ToList();
            var courseId = _repo.Courses.Where(x => x == course).Select(x => x.Id).FirstOrDefault();
            List<CourseVideos> videos = new List<CourseVideos>();
            for (int i = 0; i < course.Size; i++)
            {
                videos.Add
                    (
                        new CourseVideos
                        {
                            courseId = courseId
                        }
                    );
            }
            return View("CreateCourseVideos", videos);
        }

        public IActionResult CreateCourseVideos(List<CourseVideos> videos)
        {
            return View(videos);
        }

        [HttpPost]
        public IActionResult ResultCourseVideos(List<CourseVideos> videos)
        {
            videos.ForEach(video => _crudRepo.Update(video));
            return View("ListCourse", _repo.Courses);
        }

        public IActionResult Edit(long id)
        {
            var course = _repo.Courses.Single(c => c.Id == id);
            EditCourseModel editCourseModel = new EditCourseModel()
            {
                Description = course.Description,
                Name = course.Name,
                Price = course.Price,
                Size = course.Size,
                videos = _repo.CourseVideos.Where(x => x.courseId == id).Select(x => x).ToList()
            };
            return View(editCourseModel);
        }

        [HttpPost]
        public IActionResult Edit(EditCourseModel editCourseModel)
        {
            if (editCourseModel.Size != editCourseModel.videos.Count)
                return RedirectToAction("Index", "Home");

            var course = _crudRepo.Courses.Where(c => c.Name == editCourseModel.Name).FirstOrDefault();

            course.Description = editCourseModel.Description;
            course.Name = editCourseModel.Name;
            course.Price = editCourseModel.Price;
            course.Size = editCourseModel.Size;
            _crudRepo.Save();

            foreach (var item in editCourseModel.videos)
            {
                var courseVideos = _crudRepo.CourseVideos.Where(c => c.id == item.id).FirstOrDefault();
                courseVideos.description = item.description;
                courseVideos.lessonNumber = item.lessonNumber;
                courseVideos.videoName = item.videoName;
                courseVideos.videoPath = item.videoPath;
                _crudRepo.Save();
            }

            var courses = _repo.Courses.ToList();
            return View("ListCourse", courses);
        }

        public IActionResult Delete(long id)
        {
            var course = _repo.Courses.Single(c => c.Id == id);
            return View(course);
        }

        [HttpPost]
        public IActionResult Delete(Courses course)
        {
            _crudRepo.Delete(course);
            var deleteVideoList = _crudRepo.CourseVideos.Where(x => x.courseId == course.Id).Select(x => x).ToList();
            deleteVideoList.ForEach(x => _crudRepo.Delete(x));
            var courses = _repo.Courses.ToList();
            return View("ListCourse", courses);
        }

        public IActionResult ListBuyers()
        {
            var buyer = _repo.CourseBuying.ToList();
            if (buyer == null)
                return RedirectToAction("Index", "Home");
            return View(buyer);
        }

        public IActionResult Confirm(long id)
        {
            var buyer = _repo.CourseBuying.FirstOrDefault(c => c.Id == id);
            DataHelper.Confirm(buyer);
            _crudRepo.Delete(buyer);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RatingTable()
        {
            var gradeds = _repo.StudentsGrades.ToList();
            List<RatingTableModel> ratingTableModel = new List<RatingTableModel>();
            var students = gradeds.Select(g => g.studentId).Distinct().ToList();
            foreach (var item in students)
            {
                var course = gradeds.Where(g => g.studentId == item)
                        .Select(g => g.courseId)
                        .ToList();

                var date = gradeds
                        .Where(g => g.studentId == item)
                        .Select(g => g.date.Day.ToString() + "." + g.date.Month.ToString() + "." + g.date.Year.ToString())
                        .ToList();
                var grades = gradeds
                        .Where(g => g.studentId == item)
                        .Select(g => g.grades)
                        .ToList();
                for (int i = 0; i < grades.Count; i++)
                {
                    Dictionary<int, string> dict = new Dictionary<int, string>();
                    dict.Add(grades[i], date[i]);
                    ratingTableModel.Add(
                    new RatingTableModel()
                    {
                        courseName = _repo.Courses
                        .Where(c => c.Id == course[i])
                        .Select(c => c.Name)
                        .FirstOrDefault(),

                        gradesDate = dict,

                        studentName = _repo.Students
                        .Where(s => s.Id == item)
                        .Select(s => s.fullName)
                        .FirstOrDefault()
                    });
                }
            } 
            ViewBag.data = ratingTableModel;
            return View();
        }

        public IActionResult ListHomeWork()
        {
            var homeworks = _repo.StudentsHomework.ToList();
            var model = new List<HomeworkModel>();
            for (int i = 0; i < homeworks.Count; i++)
            {
                model.Add(
                    new HomeworkModel()
                    {
                        courseName = _repo.Courses
                        .Where(c => c.Id == homeworks[i].courseId)
                        .Select(c => c.Name)
                        .FirstOrDefault(),

                        filePath = homeworks[i].filePath,

                        studentName = _repo.Students
                        .Where(s => s.Id == homeworks[i].studentId)
                        .Select(s => s.fullName)
                        .FirstOrDefault(),

                        Mark = _repo.StudentsGrades
                        .Where(g => g.studentId == homeworks[i].studentId)
                        .Select(g => g.grades)
                        .FirstOrDefault()
                    });
                if (model[i].studentName == null)
                {
                    model[i].studentName = "Директор";
                }
                
            }
            ViewBag.data = model;
            return View(model);
        }

        
        public IActionResult ListHomeWorkPost(string JsonHomework)
        {
            
            var homework = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HomeworkModel>>(JsonHomework);

            foreach (var item in homework)
            {
                var idStudent = -1;
                if (item.studentName != "Директор")
                {
                    idStudent = _repo.Students
                        .Where(s => s.fullName == item.studentName)
                        .Select(x => x.Id)
                        .FirstOrDefault();
                }

                var studentGrades = new StudentsGrades()
                {
                    courseId = _repo.Courses
                        .Where(c => c.Name == item.courseName)
                        .Select(c => c.Id)
                        .FirstOrDefault(),

                    homeworkId = _repo.StudentsHomework
                        .Where(h => h.filePath == item.filePath)
                        .Select(h => h.Id)
                        .FirstOrDefault(),

                    studentId = idStudent,

                    grades = item.Mark,

                    date = DateTime.Now
                };
                _crudRepo.Update(studentGrades);
            }
            return RedirectToAction("Index", "Home");
        }



        public FileResult Download(string path)
        {
            if (path == null)
                return null;
            var doc = System.IO.File.ReadAllBytes(_appEnvironment.WebRootPath + "//" + path);
            var fileInfo = new FileInfo(path);
            string fileName = fileInfo.Name;
            string[] splitFileName = fileName.Split('.');
            string fileType = "application/" + splitFileName[splitFileName.Length - 1];
            return File(doc, fileType, fileName);
        }

    }

}
