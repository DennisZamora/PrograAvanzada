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
    public class OfficeAssignmentsController : Controller
    {
        private readonly IOfficeAssignmentServices officeAssignmentServices;
        private readonly IPeopleServices peopleServices;

        public OfficeAssignmentsController(IOfficeAssignmentServices officeAssignmentServices, IPeopleServices peopleServices)
        {
            this.officeAssignmentServices = officeAssignmentServices;
            this.peopleServices = peopleServices;
        }
        // GET: OfficeAssignment
        public async Task<IActionResult> Index()
        {
            return View(await officeAssignmentServices.GetAllAsync());
        }

        // GET: OfficeAssignment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var OfficeAssignment = await officeAssignmentServices.GetOneByIdAsync((int)id);
            if (OfficeAssignment == null)
            {
                return NotFound();
            }

            return View(OfficeAssignment);
        }

        /// GET: OfficeAssignments/Create
        public IActionResult Create()
        {
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator");
            return View();
        }

        // POST: OfficeAssignments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,Location")] OfficeAssignment officeAssignment)
        {
            if (ModelState.IsValid)
            {
                officeAssignmentServices.Insert(officeAssignment);
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator", officeAssignment.InstructorId);
            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = officeAssignmentServices.GetOneById((int)id);
            if (officeAssignment == null)
            {
                return NotFound();
            }
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator", officeAssignment.InstructorId);
            return View(officeAssignment);
        }

        // POST: OfficeAssignments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InstructorId,Location")] OfficeAssignment officeAssignment)
        {
            if (id != officeAssignment.InstructorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    officeAssignmentServices.Update(officeAssignment);
                }
                catch (Exception)
                {
                    if (!OfficeAssignmentExists(officeAssignment.InstructorId))
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
            ViewData["InstructorId"] = new SelectList(peopleServices.GetAll(), "Id", "Discriminator", officeAssignment.InstructorId);
            return View(officeAssignment);
        }

        // GET: OfficeAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await officeAssignmentServices.GetOneByIdAsync((int)id);
        
            if (officeAssignment == null)
            {
                return NotFound();
            }

            return View(officeAssignment);
        }

        // POST: OfficeAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var officeAssignment = await officeAssignmentServices.GetOneByIdAsync((int)id);
            officeAssignmentServices.Delete(officeAssignment);
            return RedirectToAction(nameof(Index));
        }

        private bool OfficeAssignmentExists(int id)
        {
            return (officeAssignmentServices.GetOneByIdAsync((int)id) != null);
        }
    }
}
