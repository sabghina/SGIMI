using BT.Stage.SGIMI.Commun.Tools;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.WebApp.Controllers
{
    public class FournisseurController : Controller
    {
        // GET: Fournisseur
        public ActionResult Index()
        {
            // 1.get service list fournisseur 
            List<Fournisseur> fournisseurs = new List<Fournisseur>();
            for (int i = 1; i < 10; i++)
            {
                Fournisseur fournisseur = new Fournisseur
                {
                    Id = i,
                    Nom = "Fournisseur" + i,
                    CreatedBy = i + 1
                };

                fournisseurs.Add(fournisseur);
            }

            // 2. transpose entity -> view model
            List<FournisseurViewModel> fournisseurViewModels = FournisseurTranspose.FournisseurListToFournisseurViewModelList(fournisseurs);

            return View(fournisseurViewModels);
        }

        // GET: Fournisseur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Fournisseur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fournisseur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Fournisseur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fournisseur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
