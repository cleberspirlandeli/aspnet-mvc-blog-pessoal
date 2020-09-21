using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogPessoal.Web.Data.Context;
using BlogPessoal.Web.Models;

namespace BlogPessoal.Web.Controllers
{
    public class ArtigoController : Controller
    {
        private Context db = new Context();

        // GET: Artigo
        public ActionResult Index()
        {
            var artigo = db.Artigo
                            .Include(a => a.Autor)
                            .Include(a => a.CategoriaArtigo);
            return View(artigo.ToList());
        }

        // GET: Artigo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigo.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            return View(artigo);
        }

        // GET: Artigo/Create
        public ActionResult Create()
        {
            ViewBag.IdAutor = new SelectList(db.Autor, "Id", "Nome");
            ViewBag.IdCategoriaArtigo = new SelectList(db.CategoriaArtigo, "Id", "Nome");
            return View();
        }

        // POST: Artigo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Conteudo,DataPublicacao,IdCategoriaArtigo,IdAutor,Removido")] Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                db.Artigo.Add(artigo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAutor = new SelectList(db.Autor, "Id", "Nome", artigo.IdAutor);
            ViewBag.IdCategoriaArtigo = new SelectList(db.CategoriaArtigo, "Id", "Nome", artigo.IdCategoriaArtigo);
            return View(artigo);
        }

        // GET: Artigo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigo.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAutor = new SelectList(db.Autor, "Id", "Nome", artigo.IdAutor);
            ViewBag.IdCategoriaArtigo = new SelectList(db.CategoriaArtigo, "Id", "Nome", artigo.IdCategoriaArtigo);
            return View(artigo);
        }

        // POST: Artigo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Conteudo,DataPublicacao,IdCategoriaArtigo,IdAutor,Removido")] Artigo artigo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artigo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAutor = new SelectList(db.Autor, "Id", "Nome", artigo.IdAutor);
            ViewBag.IdCategoriaArtigo = new SelectList(db.CategoriaArtigo, "Id", "Nome", artigo.IdCategoriaArtigo);
            return View(artigo);
        }

        // GET: Artigo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artigo artigo = db.Artigo.Find(id);
            if (artigo == null)
            {
                return HttpNotFound();
            }
            return View(artigo);
        }

        // POST: Artigo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artigo artigo = db.Artigo.Find(id);
            db.Artigo.Remove(artigo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
