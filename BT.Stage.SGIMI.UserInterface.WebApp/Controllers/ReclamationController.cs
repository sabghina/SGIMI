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
    public class ReclamationController : Controller
    {
        readonly IReclamationRepository reclamationRepository;
        public ReclamationController(IReclamationRepository _reclamationRepository)
        {
            reclamationRepository = _reclamationRepository;
        }

        // GET: Reclamation
        public ActionResult Index()
        {
            // 1.get service list reclamation 
            List<Reclamation> reclamations = reclamationRepository.GetReclamations();

            // 2. transpose entity -> view model
            List<ReclamationViewModel> reclamationViewModels = ReclamationTranspose.ReclamationListToReclamationViewModelList(reclamations);

            return View(reclamationViewModels);
        }

        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            Reclamation reclamation = reclamationRepository.GetReclamationById(id);

            ReclamationViewModel reclamationViewModel = ReclamationTranspose.ReclamationToReclamationViewModel(reclamation);
            return View(reclamationViewModel);
        }

        // GET: Reclamation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reclamation/Create
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

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reclamation/Edit/5
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

        // GET: Reclamation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reclamation/Delete/5
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
