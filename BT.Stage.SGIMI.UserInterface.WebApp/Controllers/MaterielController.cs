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
    [Authorize]
    public class MaterielController : Controller
    {
        readonly IMaterielRepository materielRepository;
        public MaterielController(IMaterielRepository _materielRepository)
        {
             materielRepository = _materielRepository;
        }
        
        // GET: Materiel
        public ActionResult Index()
        {
             // 1.get service list materiel 
             List<Materiel> materiels = materielRepository.GetMateriels();

             // 2. transpose entity -> view model
             List<MaterielViewModel> materielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(materiels);

             return View(materielViewModels);
        }

        // GET: Materiel/Details/5
        public ActionResult Details(int id)
        {
             Materiel materiel = materielRepository.GetMaterielById(id);

            MaterielViewModel materielViewModel = MaterielTranspose.MaterielToMaterielViewModel(materiel);
             return View(materielViewModel);
        }

        // GET: Materiel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Materiel/Create
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

        // GET: Materiel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Materiel/Edit/5
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

        // GET: Materiel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Materiel/Delete/5
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
