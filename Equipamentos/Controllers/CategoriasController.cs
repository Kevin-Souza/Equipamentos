using Equipamentos.Context;
using Equipamentos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Equipamentos.Controllers
{
    public class CategoriasController : Controller
    {
        private EFContext context = new EFContext();

        private static IList<Categoria> categorias = new List<Categoria>()
        {
            new Categoria()
            {
                CategoriaID = 1,
                Nome = "Notebooks"
            },
            new Categoria()
            {
                CategoriaID = 2,
                Nome = "Monitores"
            },
            new Categoria()
            {
                CategoriaID = 3,
                Nome = "Impressoras"
            }
        };
        // GET: Categorias
        public ActionResult Index()
        {
            return View(categorias);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Categoria categoria)
        {
            categoria.CategoriaID = categorias.Select(m => m.CategoriaID).Max() + 1;
            categorias.Add(categoria);
            return RedirectToAction("Index");
        }

        public ActionResult Edit (long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = context.categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Categoria categoria = context.categorias.Find(id);
            context.categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}