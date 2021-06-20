using System;
using System.Linq;
using App.Models.Data;
using App.Models.Entities;
using System.Threading.Tasks;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication10.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUniversityDbContext _dbContext;

        public StudentController(IStudentService studentService, IUniversityDbContext dbContext)
        {
            _studentService = studentService;
            _dbContext = dbContext;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(_studentService.GetAll());
        }

        public ActionResult CourseInStudent(Guid id)
        {
            var stdudent = _dbContext.Courses.Where(x => x.Id == id);
            return View(stdudent);
        }


        public ActionResult FacultyInStudent(Guid id)
        {
            var stdudent = _dbContext.Faculties.Where(x => x.Id == id);
            return View(stdudent);
        }

        // GET: StudentController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_studentService.Get(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.Courses = new SelectList(_dbContext.Courses, "Id", "Name");

            if (_dbContext.Faculties.Count > 0)
            {
                ViewBag.Faculties = new SelectList(_dbContext.Faculties, "Id", "Name");
            }

            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            try
            {
                student.Id = Guid.NewGuid();
                _studentService.Add(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.Courses = new SelectList(_dbContext.Courses, "Id", "Name");
            ViewBag.Faculties = new SelectList(_dbContext.Faculties, "Id", "Name");

            return View(_studentService.Get(id));
        }

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Student student)
        {
            try
            {
                if (id != student.Id)
                {
                    return NotFound();
                }

                _studentService.Update(student);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_studentService.Get(id));
        }

        // POST: StudentController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Student student)
        {
            try
            {
                if (id != student.Id)
                {
                    return NotFound();
                }

                _studentService.Delete(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}