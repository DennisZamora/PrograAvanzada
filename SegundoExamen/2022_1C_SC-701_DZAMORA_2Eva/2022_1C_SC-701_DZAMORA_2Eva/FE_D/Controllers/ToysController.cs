using FE_D.Models;
using FE_D.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE_D.Controllers
{
    public class ToysController : Controller
    {
        private readonly IKidsServices KidsServices;
        private readonly IToysServices ToysServices;

        public ToysController(IKidsServices kidsServices, IToysServices toysServices)
        {
            KidsServices = kidsServices;
            ToysServices = toysServices;
        }

        // GET: Toys
        public async Task<IActionResult> Index()
        {
            return View(await ToysServices.GetAllAsync());
        }

        // GET: Toys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await ToysServices.GetOneByIdAsync((int)id);
            if (toys == null)
            {
                return NotFound();
            }

            return View(toys);
        }

        // GET: Toys/Create
        public IActionResult Create()
        {
            ViewData["KidId"] = new SelectList(KidsServices.GetAll(), "Id", "Id");
            return View();
        }

        // POST: Toys/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KidId,Name,Colour")] Toys toys)
        {
            if (ModelState.IsValid)
            {
                ToysServices.Insert(toys);
                return RedirectToAction(nameof(Index));
            }
            ViewData["KidId"] = new SelectList(KidsServices.GetAll(), "Id", "Id", toys.KidId);
            return View(toys);
        }

        // GET: Toys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await ToysServices.GetOneByIdAsync((int)id);
            if (toys == null)
            {
                return NotFound();
            }
            ViewData["KidId"] = new SelectList(KidsServices.GetAll(), "Id", "Id", toys.KidId);
            return View(toys);
        }

        // POST: Toys/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KidId,Name,Colour")] Toys toys)
        {
            if (id != toys.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ToysServices.Update(toys);
                }
                catch (Exception ex)
                {
                    if (!ToysExists(toys.Id))
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
            ViewData["KidId"] = new SelectList(KidsServices.GetAll(), "Id", "Id", toys.KidId);
            return View(toys);
        }

        // GET: Toys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var toys = await ToysServices.GetOneByIdAsync((int)id);
            if (toys == null)
            {
                return NotFound();
            }

            return View(toys);
        }

        // POST: Toys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var toys = await ToysServices.GetOneByIdAsync((int)id);
            ToysServices.Delete(toys);
            return RedirectToAction(nameof(Index));
        }

        private bool ToysExists(int id)
        {
            return (ToysServices.GetOneByIdAsync((int) id) != null);
        }




    }
}
