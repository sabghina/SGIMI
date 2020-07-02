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
    public class AvisController : Controller
    {
        readonly IAvisRepository avisRepository;
        public AvisController(IAvisRepository _avisRepository)
        {
            avisRepository = _avisRepository;
        }
        // GET: Fournisseur Active
        public ActionResult Index()
        {
            // 1.get service list fournisseur 
            List<Avis> aviss = avisRepository.GetAvis();

            // 2. transpose entity -> view model
            List<AvisViewModel> avisViewModels = AvisTranspose.AvisListToAvisViewModelList(aviss);
            return View(avisViewModels);
        }

        // GET: Avis/Create
        public ActionResult Create()
        {
            AvisViewModel avisViewModel = new AvisViewModel();
            return View(avisViewModel);
        }

        // POST: Avis/Create
        [HttpPost]
        public ActionResult Create(AvisViewModel avisViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(avisViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
                Avis avis = AvisTranspose.CreateAvisViewModelToAvis(avisViewModel, user);

                bool avisIsCreated = avisRepository.CreateAvis(avis);
                if (avisIsCreated)
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
    }
}