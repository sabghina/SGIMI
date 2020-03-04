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
    public class InterventionController : Controller
    {
        readonly IInterventionRepository interventionRepository;
        public InterventionController(IInterventionRepository _interventionRepository)
        {
            interventionRepository = _interventionRepository;
        }

        // GET: Intervention
        public ActionResult Index()
        {
            // 1.get service list intervention 
            List<Intervention> interventions = interventionRepository.GetInterventions();

            // 2. transpose entity -> view model
            List<InterventionViewModel> interventionViewModels = InterventionTranspose.InterventionListToInterventionViewModelList(interventions);

            return View(interventionViewModels);
        }

        // GET: Intervention/Details/5
        public ActionResult Details(int id)
        {
            Intervention intervention = interventionRepository.GetInterventionById(id);

            InterventionViewModel interventionViewModel = InterventionTranspose.InterventionToInterventionViewModel(intervention);
            return View(interventionViewModel);
        }

        // GET: Intervention/Create
        public ActionResult Create()
        {
            InterventionViewModel interventionViewModel = new InterventionViewModel();
            return View(interventionViewModel);
        }

        // POST: Intervention/Create
        [HttpPost]
        public ActionResult Create(InterventionViewModel interventionViewModel)
        {
            try
            {
                // controle existance email
                //ModelState.AddModelError("Email", "Email existe");
                // controle
                if (!ModelState.IsValid)
                {
                    return View(interventionViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
                Intervention intervention = InterventionTranspose.InterventionViewModelToIntervention(interventionViewModel, user);

                bool interventionIsCreated = interventionRepository.CreateIntervention(intervention);
                if (interventionIsCreated)
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
                throw;
            }
        }


        // GET: Intervention/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Intervention/Edit/5
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

        // GET: Intervention/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Intervention/Delete/5
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
