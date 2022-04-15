using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly IPeopleServices peopleServices;
        //private readonly ICourseServices courseServices;
        private readonly IEnrollmentServices enrollmentServices;

        public EnrollmentsController(IPeopleServices peopleServices, /*ICourseServices courseServices,*/ IEnrollmentServices enrollmentServices)
        {
            this.peopleServices = peopleServices;
            //this.courseServices = courseServices;
            this.enrollmentServices = enrollmentServices;
        }
        // GET: Enrollments
        public async Task<IActionResult> Index()
        {
            return View(await enrollmentServices.GetAllAsync());
        }

        // GET: Enrollments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await enrollmentServices.GetOneByIdAsync((int)id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // GET: Enrollments/Create
        public IActionResult Create()
        {
            //ViewData["CourseId"] = new SelectList(courseServices.GetAll(), "CourseId", "CourseId");
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator");
            return View();
        }

        // POST: Enrollments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnrollmentId,CourseId,StudentId,Grade")] Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollmentServices.Insert(enrollment);
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CourseId"] = new SelectList(courseServices.GetAll(), "CourseId", "CourseId", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await enrollmentServices.GetOneByIdAsync((int)id);
            if (enrollment == null)
            {
                return NotFound();
            }
            //ViewData["CourseId"] = new SelectList(courseServices.GetAll(), "CourseId", "CourseId", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator", enrollment.StudentId);
            return View(enrollment);
        }

        // POST: Enrollments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnrollmentId,CourseId,StudentId,Grade")] Enrollment enrollment)
        {
            if (id != enrollment.EnrollmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    enrollmentServices.Update(enrollment);
                }
                catch (Exception)
                {
                    if (!EnrollmentExists(enrollment.EnrollmentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            //ViewData["CourseId"] = new SelectList(courseServices.GetAll(), "CourseId", "CourseId", enrollment.CourseId);
            ViewData["StudentId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator", enrollment.StudentId);
            return View(enrollment);
        }

        // GET: Enrollments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var enrollment = await enrollmentServices.GetOneByIdAsync((int)id);
            if (enrollment == null)
            {
                return NotFound();
            }

            return View(enrollment);
        }

        // POST: Enrollments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var enrollment = await enrollmentServices.GetOneByIdAsync((int)id);
            enrollmentServices.Delete(enrollment);
            return RedirectToAction(nameof(Index));
        }

        private bool EnrollmentExists(int id)
        {
            return (enrollmentServices.GetOneByIdAsync((int)id) != null);
        }
    }
}
