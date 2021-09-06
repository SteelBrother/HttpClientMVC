using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestCallApi.Data;
using TestCallApi.Models;
using TestCallApi.Services;

namespace TestCallApi.Controllers
{
    public class PersonController : Controller
    {
        private readonly TestCallApiContext _context;
        private readonly IPersonService _personService = null;

        public PersonController(TestCallApiContext context, IPersonService personService)
        {
            _context = context;
            _personService = personService;
        }

        // GET: Person
        public async Task<IActionResult> Index()
        {
            var persons = await _personService.GetPersons();
            return View(persons);

        }

        // GET: Person/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var actividad = await _personService.GetPerson(id);
            return View(actividad);
        }

        // GET: Person/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,FechaNacimiento,Edad")] Person person)
        {
            try
            {
                var result = await _personService.CreatePerson(person);
                TempData["Message"] = "SUCCESS!!!";
                return View(person);
            }
            catch (System.Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View(person);
            }
        }

        // GET: Person/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var person = await _personService.GetPerson(id);
            if (person == null)
            {
                return NotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,FechaNacimiento,Edad")] Person person)
        {
            try
            {
                var result = await _personService.UpdatePerson(person.Id, person);
                TempData["Message"] = "SUCCESS!!!";
                return View(person);
            }
            catch (System.Exception ex)
            {
                TempData["Message"] = ex.Message;
                return View(person);
            }
        }

        // GET: Person/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _personService.DeletePerson(id);
                TempData["Message"] = "SUCCESS!!!";
                return RedirectToAction("ListarActividades");
            }
            catch (System.Exception ex)
            {
                TempData["Message"] = ex.Message;
                return RedirectToAction("ListarActividades");
            }
        }

        // POST: Person/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var person = await _context.Person.FindAsync(id);
            _context.Person.Remove(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonExists(int id)
        {
            return _context.Person.Any(e => e.Id == id);
        }
    }
}
