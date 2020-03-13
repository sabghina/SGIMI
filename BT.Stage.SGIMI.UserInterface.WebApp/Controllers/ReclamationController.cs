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
        public ActionResult Create(string materiel)
        {
            ReclamationViewModel reclamationViewModel = new ReclamationViewModel();
            reclamationViewModel.Materiel = materiel;
            return View(reclamationViewModel);
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(int materiel,ReclamationViewModel reclamationViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(reclamationViewModel);
                }
                //string user = User.Identity.Name;
                Reclamation reclamation = ReclamationTranspose.ReclamationViewModelToReclamation(reclamationViewModel);

                bool reclamationIsCreated = reclamationRepository.CreateReclamation(reclamation);
                if (reclamationIsCreated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new InvalidOperationException("oops");
                }
            }
            catch
            {
                throw new InvalidOperationException("sorry you can't insert this item");
            }
        }

        // GET: Reclamation/Edit/5
        public ActionResult Edit(int id)
        {
            Reclamation reclamation = reclamationRepository.GetReclamationById(id);
            ReclamationViewModel reclamationViewModel = ReclamationTranspose.ReclamationToReclamationViewModel(reclamation);
            return View(reclamationViewModel);
        }

        // POST: Reclamation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ReclamationViewModel reclamationViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(reclamationViewModel);
                }
                // TODO: Add update logic here
                string user = User.Identity.Name;
                Reclamation reclamation = ReclamationTranspose.UpdatedReclamationViewModelToUpdatedReclamation(id, reclamationViewModel, user);

                bool reclamationIsUpdated = reclamationRepository.UpdatedReclamation(reclamation);
                if (reclamationIsUpdated)
                {
                    return RedirectToAction("Details", new
                    {
                        id = reclamation.Id
                    });
                }
                else
                {
                    throw new InvalidOperationException("oops");
                }
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
