using FE.Models;
using FE.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class AnimesController : Controller
    {
        private readonly IAnimesServices AnimesService;

        public AnimesController(IAnimesServices _AnimesService)
        {
            AnimesService = _AnimesService;
        }

        // GET: Animes
        public async Task<IActionResult> Index()
        {
            return View(AnimesService.GetAll());
        }

        // GET: Animes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Animes = AnimesService.GetOneById((int)id);
            if (Animes == null)
            {
                return NotFound();
            }

            return View(Animes);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,Creacion,Modificado,ModificadoPor")] Anime Animes)
        {
            if (ModelState.IsValid)
            {
                AnimesService.Insert(Animes);
                return RedirectToAction(nameof(Index));
            }
            return View(Animes);
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Animes = AnimesService.GetOneById((int)id);
            if (Animes == null)
            {
                return NotFound();
            }
            return View(Animes);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nombre, Descripcion, Creacion, Modificado, ModificadoPor")] Anime Animes)
        {
            if (id != Animes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    AnimesService.Update(Animes);
                }
                catch (Exception ee)
                {
                    if (!AnimesExists(Animes.Id))
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
            return View(Animes);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Animes = AnimesService.GetOneById((int)id);
            if (Animes == null)
            {
                return NotFound();
            }

            return View(Animes);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Animes = AnimesService.GetOneById((int)id);
            AnimesService.Delete(Animes);
            return RedirectToAction(nameof(Index));
        }

        private bool AnimesExists(int id)
        {
            return (AnimesService.GetOneById((int)id) != null);
        }
    }
}
