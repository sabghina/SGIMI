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
    public class ReclamationController : Controller
    {
        readonly IReclamationRepository reclamationRepository;
        readonly IUniteGestionRepository uniteGestionRepository;
        readonly IMaterielRepository materielRepository;
        public ReclamationController(IReclamationRepository _reclamationRepository, IUniteGestionRepository _uniteGestionRepository, IMaterielRepository _materielRepository)
        {
            reclamationRepository = _reclamationRepository;
            uniteGestionRepository = _uniteGestionRepository;
            materielRepository = _materielRepository;
        }

        // GET: Reclamation En Attente
        public ActionResult Index()
        {
            // 1.get service list reclamation 
            List<Reclamation> reclamations = reclamationRepository.GetReclamations();
            List<Materiel> materiels = materielRepository.GetComplainedMateriels();
            // 2. transpose entity -> view model
            List<ReclamationViewModel> reclamationViewModels = ReclamationTranspose.ReclamationListToReclamationViewModelList(reclamations, materiels);

            return View(reclamationViewModels);
        }

        // GET: Reclamation User En Attente
        public ActionResult UserOnHold()
        {
            // 1.get service list reclamation 
            string currentUser = User.Identity.Name;
            List<Reclamation> userReclamations = reclamationRepository.GetUserReclamations(currentUser);
            List<Materiel> materiels = materielRepository.GetComplainedMateriels();
            // 2. transpose entity -> view model
            List<ReclamationViewModel> reclamationViewModels = ReclamationTranspose.ReclamationListToReclamationViewModelList(userReclamations, materiels);

            return View(reclamationViewModels);
        }



        // GET: Reclamation En cours
        public ActionResult InProgress()
        {
            // 1.get service list reclamation 
            List<Reclamation> reclamations = reclamationRepository.GetInProgressReclamations();
            List<Materiel> materiels = materielRepository.GetComplainedMateriels();
            // 2. transpose entity -> view model
            List<ReclamationViewModel> reclamationViewModels = ReclamationTranspose.ReclamationListToReclamationViewModelList(reclamations, materiels);

            return View(reclamationViewModels);
        }
        // Get: Reclamation Terminée
        public ActionResult Finished()
        {
            // 1.get service list reclamation 
            List<Reclamation> reclamations = reclamationRepository.GetFinishedReclamations();
            List<Materiel> materiels = materielRepository.GetAffectedMateriels();
            foreach (Materiel materiel in materielRepository.GetComplainedMateriels())
            {
                materiels.Add(materiel);
            }
            // 2. transpose entity -> view model
            List<ReclamationViewModel> reclamationViewModels = ReclamationTranspose.ReclamationListToReclamationViewModelList(reclamations, materiels);

            return View(reclamationViewModels);
        }
        //Get: Reclamation Annulée
        public ActionResult Canceled()
        {
            // 1.get service list reclamation 
            List<Reclamation> reclamations = reclamationRepository.GetCanceledReclamations();
            List<Materiel> materiels = materielRepository.GetAffectedMateriels();
            // 2. transpose entity -> view model
            List<ReclamationViewModel> reclamationViewModels = ReclamationTranspose.ReclamationListToReclamationViewModelList(reclamations, materiels);

            return View(reclamationViewModels);
        }
        // GET: Reclamation/Details/5
        public ActionResult Details(int id)
        {
            Reclamation reclamation = reclamationRepository.GetReclamationById(id);
            Materiel materiel = materielRepository.GetMaterielById(reclamation.Materiel);
            ReclamationViewModel reclamationViewModel = ReclamationTranspose.ReclamationToReclamationViewModel(reclamation, materiel);
            return View(reclamationViewModel);
        }


        // GET: Reclamation/Create
        public ActionResult Create(int materiel)
        {
            List<UniteGestion> uniteGestions = uniteGestionRepository.GetUniteGestions();
            IEnumerable<SelectListItem> uniteGestionsSelectListItem = new SelectList(uniteGestions.Select(
                uniteGestion => new
                {
                    Id = uniteGestion.Id,
                    Text = uniteGestion.Nom
                }).AsEnumerable(), "Text", "Text");

            CreateReclamationViewModel createReclamationViewModel = new CreateReclamationViewModel
            {
                UniteGestions = uniteGestionsSelectListItem
            };
            createReclamationViewModel.Materiel = materiel;
            return View(createReclamationViewModel);
        }

        // POST: Reclamation/Create
        [HttpPost]
        public ActionResult Create(int materiel, CreateReclamationViewModel createReclamationViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<UniteGestion> uniteGestions = uniteGestionRepository.GetUniteGestions();
                    IEnumerable<SelectListItem> uniteGestionsSelectListItem = new SelectList(uniteGestions.Select(
                        uniteGestion => new
                        {
                            Id = uniteGestion.Id,
                            Text = uniteGestion.Nom
                        }).AsEnumerable(), "Text", "Text");
                    createReclamationViewModel.UniteGestions = uniteGestionsSelectListItem;
                    return View(createReclamationViewModel);

                }
                //string user = User.Identity.Name;
                // Materiel materiel = materielRepository.GetMaterielById(materielId);
                string user = User.Identity.Name;
                Reclamation reclamation = ReclamationTranspose.CreateReclamationViewModelToReclamation(createReclamationViewModel, user);
                Materiel materielById = materielRepository.GetMaterielById(reclamation.Materiel);
                bool reclamationIsCreated = reclamationRepository.CreateReclamation(reclamation);
                if (reclamationIsCreated)
                {
                    Materiel materielStatut = MaterielTranspose.ChangeMaterielStatut(materielById, user, "Reclamé");
                    bool materielIsChanged = materielRepository.ChangeMateriel(materielStatut);
                    if (materielIsChanged)
                    {
                        return RedirectToAction("Index");
                    }
                    {
                        throw new InvalidOperationException("Désolé");
                    }
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
            Materiel materiel = materielRepository.GetMaterielById(reclamation.Materiel);
            CreateReclamationViewModel createReclamationViewModel = ReclamationTranspose.ReclamationToCreateReclamationViewModel(reclamation, materiel);
            List<UniteGestion> uniteGestions = uniteGestionRepository.GetUniteGestions();
            IEnumerable<SelectListItem> uniteGestionsSelectListItem = new SelectList(uniteGestions.Select(
                uniteGestion => new
                {
                    Id = uniteGestion.Id,
                    Text = uniteGestion.Nom
                }).AsEnumerable(), "Text", "Text");

            createReclamationViewModel.UniteGestions = uniteGestionsSelectListItem;
            
            return View(createReclamationViewModel);
        }

        // POST: Reclamation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreateReclamationViewModel createReclamationViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<UniteGestion> uniteGestions = uniteGestionRepository.GetUniteGestions();
                    IEnumerable<SelectListItem> uniteGestionsSelectListItem = new SelectList(uniteGestions.Select(
                        uniteGestion => new
                        {
                            Id = uniteGestion.Id,
                            Text = uniteGestion.Nom
                        }).AsEnumerable(), "Text", "Text");
                    createReclamationViewModel.UniteGestions = uniteGestionsSelectListItem;
                    return View(createReclamationViewModel);
                }
                // TODO: Add update logic here
                string user = User.Identity.Name;
                Reclamation oldReclamation = reclamationRepository.GetReclamationById(id);
                Reclamation reclamation = ReclamationTranspose.UpdatedReclamationViewModelToUpdatedReclamation(oldReclamation, createReclamationViewModel, user);

                bool reclamationIsUpdated = reclamationRepository.UpdatedReclamation(reclamation);
                if (reclamationIsUpdated)
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
                return View();
            }
        }

        // GET: Intervention/Annuler
        public ActionResult Annuler(int id)
        {
            try
            {
                Reclamation reclamation = reclamationRepository.GetReclamationById(id);
                Materiel materiel = materielRepository.GetMaterielById(reclamation.Materiel);
                ReclamationViewModel reclamationViewModel = ReclamationTranspose.ReclamationToReclamationViewModel(reclamation, materiel);
                return View(reclamationViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // POST: Intervention/Annuler
        [HttpPost]
        public ActionResult Annuler(int id, ReclamationViewModel reclamationViewModel)
        {
            try
            {
                string user = User.Identity.Name;
                Reclamation oldReclamation = reclamationRepository.GetReclamationById(id);
                Reclamation reclamation = ReclamationTranspose.AnnulerReclamationViewModelToAnnulerReclamation(oldReclamation, user);
                Materiel materielById = materielRepository.GetMaterielById(reclamation.Materiel);
                bool reclamationIsCanceled = reclamationRepository.CanceledReclamation(reclamation);
                if (reclamationIsCanceled)
                {
                    Materiel materielStatut = MaterielTranspose.ChangeMaterielStatut(materielById, user, "Non reclamé");
                    bool materielIsChanged = materielRepository.ChangeMateriel(materielStatut);
                    if (materielIsChanged)
                    {
                        return RedirectToAction("Canceled");
                    }
                    else
                    {
                        throw new InvalidOperationException("oops");
                    }
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
        // Static Reports (tous les reclamations)
        public FileResult StaticReports()
        {
            byte[] file = reclamationRepository.StaticReports();
            string filename = $"static_reports_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }


        // Static Report (un seul materiel)
        public FileResult StaticReport(int id)
        {
            byte[] file = reclamationRepository.StaticReport();
            string filename = $"static_report_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Reports (tous les materiels)
        public FileResult DynamicReports()
        {
            List<Reclamation> reclamations = reclamationRepository.GetReclamations();
            List<Materiel> materiels = materielRepository.GetMateriels();
            List<ReclamationReport> reclamationReports = ReclamationTranspose.ReclamationListToReclamationReportList(reclamations, materiels);
            byte[] file = reclamationRepository.DynamicReports(reclamationReports);
            string filename = $"ListeReclamations_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Report (un seul materiel)
        public FileResult DynamicReport(int id)
        {
            Reclamation reclamation = reclamationRepository.GetReclamationById(id);
            Materiel materiel = materielRepository.GetMaterielById(reclamation.Materiel);
            ReclamationReport reclamationReport = ReclamationTranspose.ReclamationToReclamationReport(reclamation, materiel);
            byte[] file = reclamationRepository.DynamicReport(reclamationReport);
            string filename = $"DetailsReclamation_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }
    }
}
