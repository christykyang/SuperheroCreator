using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperheroCreator.Data;
using SuperheroCreator.Models;

namespace SuperheroCreator.Controllers
{
    public class SuperheroController : Controller
    {
        public ApplicationDbContext _context;
        private object context;

        public object Superheroes { get; private set; }

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superhero
        public ActionResult Index()
        {
            var superhero = _context.Superheroes;
            return View(superhero);
        }

        // GET: Superhero/Details/5
        public ActionResult Details(int id)
        {
            //Superhero superhero = new Superhero();
            //superhero.SuperheroId = id;
            var superhero = _context.Superheroes.Where(s => s.SuperheroId == id).Single();
            return View(superhero);
        }

        // GET: Superhero/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero superhero = new Superhero();
            superhero.SuperheroId = id;
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add update logic here
                Superhero newHero = new Superhero();
                newHero = _context.Superheroes.Where(a => a.SuperheroId == superhero.SuperheroId).Single();
                newHero.SuperheroId = superhero.SuperheroId;
                newHero.Name = superhero.Name;
                newHero.AlterEgoName = superhero.AlterEgoName;
                newHero.PrimarySuperpower = superhero.PrimarySuperpower;
                newHero.SecondarySuperpower = superhero.SecondarySuperpower;
                newHero.CatchPhrase = superhero.CatchPhrase;
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }

        }

        // GET: Superhero/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero superhero = new Superhero();
            superhero.SuperheroId = id;
            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Superheroes.Remove(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}