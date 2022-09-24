using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationTeacher.Abstract;
using WebApplicationTeacher.Data;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Controllers
{
    public class AboutCourseController : Controller
    {
        private readonly ICourseRepository _repo;
        private readonly ICRUDRepository _crudRepo;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly UserManager<AppUser> _userManager;

        public AboutCourseController(
            ICourseRepository repo, IWebHostEnvironment appEnvironment, 
            ICRUDRepository credRepo, UserManager<AppUser> userManager)
        {
            _repo = repo;
            _appEnvironment = appEnvironment;
            _crudRepo = credRepo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var course = _repo.Courses.ToList();
            return View(course);
        }

        public IActionResult Course(long Id)
        {
            var course = _repo.Courses.Single(p => p.Id == Id);
            var videos = _repo.CourseVideos
                .Where(x => x.courseId == Id)
                .OrderBy(x => x.lessonNumber)
                .Select(x => x)
                .ToList();
            ViewBag.Videos = videos;
            return View(course);
        }

        public IActionResult CourseBuying(long Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        [HttpPost]
        public IActionResult CourseBuying(BuyerModel model)
        {
            var buyer = new CourseBuyingModel()
            {
                Course = model.Course,
                PhoneNumber = model.PhoneNumber,
                SocialNetwork = model.SocialNetwork
            };
            var user = User;
            DataHelper.SaveBuyerChanges(buyer, user);
            var course = _repo.Courses.ToList();
            return View("Index", course);
        }

        
        public IActionResult AddHomework(int id)
        {
            var video = _repo.CourseVideos.Where(s => s.id == id).FirstOrDefault();
            var studentId = -1;
            if (User.IsInRole("Student"))
            {
                var name = _userManager.Users
                .Where(u => u.Id == _userManager.GetUserId(User))
                .Select(u => u.Firstname + " " + u.Lastname)
                .FirstOrDefault();
                studentId = _repo.Students.Where(s => s.fullName == name).Select(s => s.Id).FirstOrDefault();
            }
            
            var model = new StudentsHomework()
            {
                courseId = video.courseId,
                videoId = video.id,
                studentId = studentId
            };

            
            return View(model);
        }
         
        public async Task<IActionResult> LoadFile(IFormFile uploadedFile, StudentsHomework studentsHomework)
        {
            studentsHomework.Id = 0;
            if (uploadedFile != null)
            {
                string courseName = _repo.Courses
                    .Where(c => c.Id == studentsHomework.courseId)
                    .Select(c => c.Name).FirstOrDefault();
                string studentName = _repo.Students
                    .Where(c => c.Id == studentsHomework.studentId)
                    .Select(c => c.fullName).FirstOrDefault();
                if (studentName == null)
                    studentName = "Директор";
                var path = _appEnvironment.WebRootPath + "\\Files\\" + courseName + "\\" + studentName;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                path += "\\" + uploadedFile.FileName;

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
                studentsHomework.filePath = "\\Files\\" + courseName + "\\" + studentName + "\\" + uploadedFile.FileName;
                _crudRepo.Update(studentsHomework);
            }

            return RedirectToAction("Index");
        }
    }
}
