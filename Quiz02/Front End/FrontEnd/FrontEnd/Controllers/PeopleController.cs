﻿using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleServices PeopleServices;

        public PeopleController(IPeopleServices peopleServices)
        {
            PeopleServices = peopleServices;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            return View(PeopleServices.GetAll());
        }

        // GET: People/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = PeopleServices.GetOneById((int)id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: People/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,LastName,FirstName,HireDate,EnrollmentDate,Discriminator")] Person person)
        {
            if (ModelState.IsValid)
            {
                PeopleServices.Insert(person);
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = PeopleServices.GetOneById((int)id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        //POST: People/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,LastName,FirstName,HireDate,EnrollmentDate,Discriminator")] Person person)
        {
            if (id != person.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PeopleServices.Update(person);
                }
                catch (Exception)
                {
                    if (!PersonExists(person.Id))
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
            return View(person);
        }

        // GET: People/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = PeopleServices.GetOneById((int)id);
            if (person == null)
            {
                return NotFound();
            }

            return View(person);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = PeopleServices.GetOneById((int)id);
            PeopleServices.Delete(person);
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return (PeopleServices.GetOneById((int)id) != null);
        }

    }
}
