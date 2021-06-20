using System;
using System.Linq;
using App.Models.Entities;
using AppServices.Interfaces;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace WebApplication10.Controllers
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        // GET: FacultyController
        public ActionResult Index()
        {
            return View(_facultyService.GetAll());
        }


        // GET: FacultyController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_facultyService.Get(id));
        }

        // GET: FacultyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FacultyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faculty faculty)
        {
            try
            {
                faculty.Id = Guid.NewGuid();
                _facultyService.Add(faculty);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacultyController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_facultyService.Get(id));
        }

        // POST: FacultyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, Faculty faculty)
        {
            try
            {
                if (id != faculty.Id)
                {
                    return NotFound();
                }
                _facultyService.Update(faculty);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FacultyController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_facultyService.Get(id));
        }

        // POST: FacultyController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, Faculty faculty)
        {
            try
            {
                if (id != faculty.Id)
                {
                    return NotFound();
                }

                faculty.Status = false;
                _facultyService.Update(faculty);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}