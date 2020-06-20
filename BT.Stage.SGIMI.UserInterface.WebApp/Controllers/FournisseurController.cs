using BT.Stage.SGIMI.BusinessLogic.Implementation;
using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Commun.Tools;
using BT.Stage.SGIMI.Data.DTO;
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
    public class FournisseurController : Controller
    {
        readonly IFournisseurRepository fournisseurRepository;
        public FournisseurController(IFournisseurRepository _fournisseurRepository)
        {
            fournisseurRepository = _fournisseurRepository;
        }
        // GET: Fournisseur Active
        public ActionResult Index()
        {
            // 1.get service list fournisseur 
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();

            // 2. transpose entity -> view model
            List<FournisseurViewModel> fournisseurViewModels = FournisseurTranspose.FournisseurListToFournisseurViewModelList(fournisseurs);

            return View(fournisseurViewModels);
        }
        // GET: Fournisseur Archived
        public ActionResult Archived()
        {
            // 1.get service list fournisseur 
            
            List<Fournisseur> archivedFournisseurs = fournisseurRepository.GetArchivedFournisseurs();

            // 2. transpose entity -> view model
            List<FournisseurViewModel> archivedFournisseurViewModels = FournisseurTranspose.FournisseurListToFournisseurViewModelList(archivedFournisseurs);

            return View(archivedFournisseurViewModels);
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
            FournisseurViewModel fournisseurViewModel = new FournisseurViewModel();
            return View(fournisseurViewModel);
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(FournisseurViewModel fournisseurViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(fournisseurViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
                Fournisseur fournisseur = FournisseurTranspose.CreateFournisseurViewModelToFournisseur(fournisseurViewModel, user);

                bool fournisseurIsCreated = fournisseurRepository.CreateFournisseur(fournisseur);
                if (fournisseurIsCreated)
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

        // GET: Fournisseur/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(id);
                FournisseurViewModel fournisseurViewModel = FournisseurTranspose.FournisseurToFournisseurViewModel(fournisseur);
                return View(fournisseurViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Fournisseur/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FournisseurViewModel fournisseurViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(fournisseurViewModel);
                }
                string user = User.Identity.Name;
                Fournisseur oldFournisseur = fournisseurRepository.GetFournisseurById(id);
                Fournisseur fournisseur = FournisseurTranspose.UpdatedFournisseurViewModelToUpdatedFournisseur(oldFournisseur, fournisseurViewModel, user);
                bool fournisseurIsUpdated = fournisseurRepository.UpdatedFournisseur(fournisseur);
                if (!fournisseurIsUpdated)
                {
                    throw new Exception("oops");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }

        }

       
        // GET: Fournisseur/Archiver/5
        public ActionResult Archiver(int id)
        {
            try
            {
                Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(id);
                FournisseurViewModel fournisseurViewModel = FournisseurTranspose.FournisseurToFournisseurViewModel(fournisseur);
                return View(fournisseurViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Fournisseur/Archiver/5
        [HttpPost]
        public ActionResult Archiver(int id, FournisseurViewModel fournisseurViewModel)
        {
            try
            {
                string user = User.Identity.Name;
                Fournisseur oldFournisseur = fournisseurRepository.GetFournisseurById(id);
                Fournisseur fournisseur = FournisseurTranspose.ArchiverFournisseurViewModelToArchiverFournisseur(oldFournisseur, user);
                bool fournisseurIsArchived = fournisseurRepository.ArchivedFournisseur(fournisseur);
                if (!fournisseurIsArchived)
                {
                    throw new Exception("oops");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }

        }

        // GET: Fournisseur/Activer/5
        public ActionResult Activer(int id)
        {
            try
            {
                Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(id);
                FournisseurViewModel fournisseurViewModel = FournisseurTranspose.FournisseurToFournisseurViewModel(fournisseur);
                return View(fournisseurViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Fournisseur/Activer/5
        [HttpPost]
        public ActionResult Activer(int id, FournisseurViewModel fournisseurViewModel)
        {
            try
            {
                string user = User.Identity.Name;
                Fournisseur oldFournisseur = fournisseurRepository.GetFournisseurById(id);
                Fournisseur fournisseur = FournisseurTranspose.ActiverFournisseurViewModelToActiverFournisseur(oldFournisseur, user);
                bool fournisseurIsActivated = fournisseurRepository.ActivatedFournisseur(fournisseur);
                if (!fournisseurIsActivated)
                {
                    throw new Exception("oops");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                throw;
            }

        }

         // Static Reports (tous les fournisseurs)
        public FileResult StaticReports()
        {
            byte[] file = fournisseurRepository.StaticReports();
            string filename = $"static_reports_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }


        // Static Report (un seul fournisseur)
        public FileResult StaticReport(int id)
        {
            byte[] file = fournisseurRepository.StaticReport();
            string filename = $"static_report_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Reports (tous les fournisseurs)
        public FileResult DynamicReports()
        {
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
            List<FournisseurReport> fournisseurReports = FournisseurTranspose.FournisseurListToFournisseurReportList(fournisseurs);
            byte[] file = fournisseurRepository.DynamicReports(fournisseurReports);
            string filename = $"ListeDesContratsFournisseursActive_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Reports(tous les fournisseurs)
        public FileResult DynamicReportsArchived()
        {
            List<Fournisseur> fournisseurs = fournisseurRepository.GetArchivedFournisseurs();
            List<FournisseurReport> fournisseurReports = FournisseurTranspose.FournisseurListToFournisseurReportList(fournisseurs);
            byte[] file = fournisseurRepository.DynamicReports(fournisseurReports);
            string filename = $"ListeDesContratsFournisseursArchivé{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Report (un seul fournisseur)
        public FileResult DynamicReport(int id)
        {
            Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(id);
            FournisseurReport fournisseurReport = FournisseurTranspose.FournisseurToFournisseurReport(fournisseur);
            byte[] file = fournisseurRepository.DynamicReport(fournisseurReport);
            string filename = $"ContratFournisseur_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }
    }
}


