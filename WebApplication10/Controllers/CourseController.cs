using System;
using System.Linq;
using App.Models.Entities;
using System.Threading.Tasks;
using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace WebApplication10.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: CourseController
        public ActionResult Index()
        {
            return View(_courseService.GetAll());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_courseService.Get(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            try
            {
                course.Id = Guid.NewGuid();
                _courseService.Add(course);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_courseService.Get(id));
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Course course)
        {
            try
            {
                if (id != course.Id)
                {
                    return NotFound();
                }

                _courseService.Update(course);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_courseService.Get(id));
        }

        // POST: CourseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, [Bind("Id,Name")] Course course)
        {
            try
            {
                if (id != course.Id)
                {
                    return NotFound();
                }

                course.Status = false;

                _courseService.Update(course);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}