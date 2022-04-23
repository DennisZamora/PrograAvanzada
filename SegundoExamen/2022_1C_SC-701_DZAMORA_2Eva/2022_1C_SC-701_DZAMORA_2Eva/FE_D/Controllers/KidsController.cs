using FE_D.Models;
using FE_D.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE_D.Controllers
{
    public class KidsController : Controller
    {
        private readonly IKidsServices KidsServices;

        public KidsController(IKidsServices kidsServices)
        {
            KidsServices = kidsServices;
        }

        // GET: Kids
        public async Task<IActionResult> Index()
        {
            return View(KidsServices.GetAll());
        }

        // GET: Kids/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids = KidsServices.GetOneById((int)id);
            if (kids == null)
            {
                return NotFound();
            }

            return View(kids);
        }

        // GET: Kids/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kids/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,BirthDate")] Kids kids)
        {
            if (ModelState.IsValid)
            {
                KidsServices.Insert(kids);
                return RedirectToAction(nameof(Index));
            }
            return View(kids);
        }

        // GET: Kids/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids = KidsServices.GetOneById((int)id);
            if (kids == null)
            {
                return NotFound();
            }
            return View(kids);
        }

        // POST: Kids/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,BirthDate")] Kids kids)
        {
            if (id != kids.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    KidsServices.Update(kids);
                }
                catch (Exception ex)
                {
                    if (!KidsExists(kids.Id))
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
            return View(kids);
        }

        // GET: Kids/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kids = KidsServices.GetOneById((int) id);
            if (kids == null)
            {
                return NotFound();
            }

            return View(kids);
        }

        // POST: Kids/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kids = KidsServices.GetOneById((int)id);
            KidsServices.Delete(kids);
            return RedirectToAction(nameof(Index));
        }
        private bool KidsExists(int id)
        {
            return (KidsServices.GetOneById((int) id) != null);
        }

    }
}
