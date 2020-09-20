using BlogPessoal.Web.Data.Context;
using BlogPessoal.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BlogPessoal.Web.Controllers
{
    public class CategoriaArtigoController : Controller
    {
        private Context _context = new Context();
        // GET: CategoriaArtigo
        public ActionResult Index()
        {
            var categorias = _context.CategoriaArtigo
                    .OrderBy(x => x.Nome)
                    .ToList();

            return View(categorias);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoriaArtigo categoria)
        {
            if (ModelState.IsValid)
            {
                _context.CategoriaArtigo.Add(categoria);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var categoria = _context.CategoriaArtigo.Find(id);

            if (categoria == null)
                return HttpNotFound();

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Edit(CategoriaArtigo categoria)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(categoria).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var categoria = _context.CategoriaArtigo.Find(id);

            if (categoria == null)
                return HttpNotFound();

            return View(categoria);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var categoria = _context.CategoriaArtigo.Find(id);
            _context.CategoriaArtigo.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}