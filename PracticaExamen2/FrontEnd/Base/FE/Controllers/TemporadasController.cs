using FE.Models;
using FE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE.Controllers
{
    public class TemporadasController : Controller
    {
        private readonly IAnimesServices animesServices;
        private readonly ITemporadasServices temporadasServices;

        public TemporadasController(IAnimesServices animesService, ITemporadasServices temporadasServices)
        {
            this.animesServices = animesService;
            this.temporadasServices = temporadasServices;
        }


        // GET: Temporada
        public async Task<IActionResult> Index()
        {
            return View(await temporadasServices.GetAllAsync());
        }

        // GET: Temporada/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Temporada = await temporadasServices.GetOneByIdAsync((int)id);
            if (Temporada == null)
            {
                return NotFound();
            }

            return View(Temporada);
        }

        // GET: Temporada/Create
        public IActionResult Create()
        {
            ViewData["Id"] = new SelectList(animesServices.GetAll(), "Id", "Id");
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Temporada/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Descripcion,CantidadCapitulos,Creacion,Modificacion,ModificadoPor,IdAnime")] Temporada Temporada)
        {
            if (ModelState.IsValid)
            {
                temporadasServices.Insert(Temporada);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(animesServices.GetAll(), "Id", "Id", Temporada.Id);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", Temporada.SupplierId);
            return View(Temporada);
        }

        // GET: Temporada/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Temporada = await temporadasServices.GetOneByIdAsync((int)id);
            if (Temporada == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(animesServices.GetAll(), "Id", "Id", Temporada.Id);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", Temporada.SupplierId);
            return View(Temporada);
        }

        // POST: Temporada/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Descripcion,CantidadCapitulos,Creacion,Modificacion,ModificadoPor,IdAnime")] Temporada Temporada)
        {
            if (id != Temporada.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    temporadasServices.Update(Temporada);
                }
                catch (Exception ee)
                {
                    if (!TemporadaExists(Temporada.Id))
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
            ViewData["Id"] = new SelectList(animesServices.GetAll(), "Id", "Id", Temporada.Id);
            //ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", Temporada.SupplierId);
            return View(Temporada);
        }

        // GET: Temporada/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Temporada = await temporadasServices.GetOneByIdAsync((int)id);
            if (Temporada == null)
            {
                return NotFound();
            }

            return View(Temporada);
        }

        // POST: Temporada/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Temporada = await temporadasServices.GetOneByIdAsync((int)id);
            temporadasServices.Delete(Temporada);
            return RedirectToAction(nameof(Index));
        }

        private bool TemporadaExists(int id)
        {
            return (temporadasServices.GetOneByIdAsync((int)id) != null);
        }

    }
}
