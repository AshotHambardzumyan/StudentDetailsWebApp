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
        private readonly IFacultyService _facultyService;
        private readonly ICourseService _courseService;

        public StudentController(
            IStudentService studentService, 
            ICourseService courseService,
            IFacultyService facultyService
            )
        {
            _studentService = studentService;
            _courseService = courseService;
            _facultyService = facultyService;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            var students = _studentService.GetAll();
            foreach (var item in students)
            {
                item.Course = _courseService.Get(item.Course.Id);
                item.Faculty = _facultyService.Get(item.Faculty.Id);
            }

            return View(students);
        }
        // GET: StudentController/Details/5
        public ActionResult Details(Guid id)
        {
            var st = _studentService.Get(id);
            st.Course = _courseService.Get(st.Course.Id);
            st.Faculty = _facultyService.Get(st.Faculty?.Id);
            return View(st);
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            var allCourses = _courseService.GetAll();
            ViewBag.Courses = new SelectList(allCourses, "Id", "Name");
            var faculties = _facultyService.GetAll();
            if (faculties.Count > 0)
            {
                ViewBag.Faculties = new SelectList(faculties, "Id", "Name");
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
            ViewBag.Courses = new SelectList(_courseService.GetAll(), "Id", "Name");
            ViewBag.Faculties = new SelectList(_facultyService.GetAll(), "Id", "Name");

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