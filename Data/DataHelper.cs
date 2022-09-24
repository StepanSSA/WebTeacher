using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplicationTeacher.Domains;
using WebApplicationTeacher.Models;

namespace WebApplicationTeacher.Data
{
    public class DataHelper
    {
        private static IApplicationBuilder app;
        // для начального заполнения бд
        public async static void Seed(IApplicationBuilder _app)
        {
            app = _app;
            //  1) добавим базовые роли в систему
            var services = app.ApplicationServices;
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            string password = "!Qwerty1";
            string[] rolesNames = {"boss", "Student"};
            string[] usersNames = {"Boss@mail.ru", "Student@mail.ru" };
            string[] usersFName = { "Директор", "Студент" };
            string[] usersSName = { "Леонид", "Василий" };
            string[] usersPhoneNumber = { "123", "123" };
            int[] usersAge = { 33, 15};

            for (int i = 0; i < rolesNames.Length; i++)
            {
                string roleName = rolesNames[i];
                var role = await roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new IdentityRole()
                    {
                        Name = roleName
                    };
                    IdentityResult result = await roleManager.CreateAsync(role);
                    if (result.Succeeded)
                    {
                        var user = new AppUser()
                        {
                            UserName = usersNames[i],
                            Firstname = usersFName[i],
                            Lastname = usersSName[i],
                            Email = usersNames[i],
                            EmailConfirmed = true,
                            Age = usersAge[i],
                            PhoneNumber = usersPhoneNumber[i]
                        };
                        result = await userManager.CreateAsync(user, password);
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, roleName);
                        }

                    }
                }
                
            }

            // 2) добавляем в базу
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            if(!context.CourseVideos.Any())
            {
                context.CourseVideos.AddRange(new SimpleCourseRepository().CourseVideos);
                context.SaveChanges();
            }
            if (!context.StudentsGrades.Any())
            {
                context.StudentsGrades.AddRange(new SimpleCourseRepository().StudentsGrades);
                context.SaveChanges();
            }
            if (!context.Students.Any())
            {
                Students student = new Students()
                {
                    age = usersAge[1],
                    fullName = usersFName[1] + " " + usersSName[1],
                    sex = "M"
                };
                context.Students.Add(student);
                context.SaveChanges();
            }
            if (context.Courses.Any()) return;

            context.Courses.AddRange(new SimpleCourseRepository().Courses);
            context.SaveChanges();
        }

        public static void SaveBuyerChanges(CourseBuyingModel model, ClaimsPrincipal user)
        {
            var services = app.ApplicationServices;
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            model.Account = userManager.GetUserId(user);
            model.Firstname = userManager.Users.FirstOrDefault(u => u.Id == model.Account).Firstname;
            model.Lastname = userManager.Users.FirstOrDefault(u => u.Id == model.Account).Lastname;
            model.Age = userManager.Users.FirstOrDefault(u => u.Id == model.Account).Age;
            context.CourseBuying.Add(model);
            context.SaveChanges();
        }
        public static void SaveChanges(Courses model)
        {
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Update(model);
            context.SaveChanges();
        }

        public static async void NewRole(string addedRole, string accountId)
        {
            var services = app.ApplicationServices;
            var userManager = services.GetRequiredService<UserManager<AppUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            string roleName = "";
            if (addedRole == "Student")
                roleName = addedRole;
            else
                roleName = context.Courses.First(c => c.Id == Convert.ToInt32(addedRole)).Name;

            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new IdentityRole()
                {
                    Name = roleName
                };
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    var newUser = await userManager.FindByIdAsync(accountId);
                    await userManager.AddToRoleAsync(newUser, roleName);
                    
                }
            }else
            {
                var newUser = await userManager.FindByIdAsync(accountId);
                await userManager.AddToRoleAsync(newUser, roleName);
            }

            context.SaveChanges();
        }
        public static void Confirm(CourseBuyingModel model)
        {
            int courseid = Convert.ToInt32(model.Course);
            string accountId = model.Account;
            NewRole(courseid.ToString(), accountId);
        }

    }
}
