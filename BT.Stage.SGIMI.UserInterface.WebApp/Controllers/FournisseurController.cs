using BT.Stage.SGIMI.BusinessLogic.Interface;
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
        readonly IFournisseurRepository fournisseurRepository;
        public FournisseurController(IFournisseurRepository _fournisseurRepository)
        {
            fournisseurRepository = _fournisseurRepository;
        }
        // GET: Fournisseur
        public ActionResult Index()
        {
            // 1.get service list fournisseur 
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();

            // 2. transpose entity -> view model
            List<FournisseurViewModel> fournisseurViewModels = FournisseurTranspose.FournisseurListToFournisseurViewModelList(fournisseurs);

            return View(fournisseurViewModels);
        }

        // GET: Fournisseur/Details/5
        public ActionResult Details(int id)
        {
            Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(id);

            FournisseurViewModel fournisseurViewModel = FournisseurTranspose.FournisseurToFournisseurViewModel(fournisseur);
            return View(fournisseurViewModel);
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
