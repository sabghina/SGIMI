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
    public class InterventionController : Controller
    {
        readonly IInterventionRepository interventionRepository;
        readonly IReclamationRepository reclamationRepository;
        readonly IMaterielRepository materielRepository;
        public InterventionController(IInterventionRepository _interventionRepository, IReclamationRepository _reclamationRepository, IMaterielRepository _materielRepository)
        {
            interventionRepository = _interventionRepository;
            reclamationRepository = _reclamationRepository;
            materielRepository = _materielRepository;
        }

        // GET: Intervention
        public ActionResult Index()
        {
            // 1.get service list intervention 
            List<Intervention> interventions = interventionRepository.GetInterventions();
            List<Reclamation> reclamations = reclamationRepository.GetInProgressReclamations();
            // 2. transpose entity -> view model
            List<InterventionViewModel> interventionViewModels = InterventionTranspose.InterventionListToInterventionViewModelList(interventions, reclamations);

            return View(interventionViewModels);
        }

        // GET: Intervention
        public ActionResult Finished()
        {
            // 1.get service list intervention 
            List<Intervention> interventions = interventionRepository.GetFinishedInterventions();
            List<Reclamation> reclamations = reclamationRepository.GetFinishedReclamations();
            // 2. transpose entity -> view model
            List<InterventionViewModel> interventionViewModels = InterventionTranspose.InterventionListToInterventionViewModelList(interventions, reclamations);

            return View(interventionViewModels);
        }
        // GET: Intervention
        public ActionResult Canceled()
        {
            // 1.get service list intervention 
            List<Intervention> interventions = interventionRepository.GetCanceledInterventions();
            List<Reclamation> reclamations = reclamationRepository.GetReclamations();
            // 2. transpose entity -> view model
            List<InterventionViewModel> interventionViewModels = InterventionTranspose.InterventionListToInterventionViewModelList(interventions, reclamations);

            return View(interventionViewModels);
        }

        // GET: Intervention/Details/5
        public ActionResult Details(int id)
        {
            Intervention intervention = interventionRepository.GetInterventionById(id);
            Reclamation reclamation = reclamationRepository.GetReclamationById(intervention.Reclamation);
            InterventionViewModel interventionViewModel = InterventionTranspose.InterventionToInterventionViewModel(intervention, reclamation);
            return View(interventionViewModel);
        }
        // GET: Intervention/Create
        public ActionResult Create(int reclamation)
        {
            CreateInterventionViewModel createInterventionViewModel = new CreateInterventionViewModel();
            createInterventionViewModel.Reclamation = reclamation;
            return View(createInterventionViewModel);
        }

        // POST: Intervention/Create
        [HttpPost]
        public ActionResult Create(int reclamation, CreateInterventionViewModel createInterventionViewModel)
        {
            try
            {
                // controle existance email
                //ModelState.AddModelError("Email", "Email existe");
                // controle
                if (!ModelState.IsValid)
                {
                    return View(createInterventionViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
                Reclamation reclamationById = reclamationRepository.GetReclamationById(reclamation);
                Intervention intervention = InterventionTranspose.CreateInterventionViewModelToIntervention(reclamationById,createInterventionViewModel, user);
                
                bool interventionIsCreated = interventionRepository.CreateIntervention(intervention);
                if (interventionIsCreated)
                    {
                     Reclamation reclamationEtat = ReclamationTranspose.ChangeReclamationEtat(reclamationById, user,intervention.Etat);
                     bool reclamationIsChanged = reclamationRepository.ChangeReclamation(reclamationEtat);
                    if (reclamationIsChanged)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        throw new InvalidOperationException("oops");
                    }
                }
                else
                {
                    throw new InvalidOperationException("oops désolé");
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
            Intervention intervention = interventionRepository.GetInterventionById(id);
            Reclamation reclamation = reclamationRepository.GetReclamationById(intervention.Reclamation);
            CreateInterventionViewModel createInterventionViewModel = InterventionTranspose.InterventionToCreateInterventionViewModel(intervention, reclamation);
            return View(createInterventionViewModel);
        }

        // POST: Intervention/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreateInterventionViewModel createInterventionViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(createInterventionViewModel);
                }
                // TODO: Add update logic here
                string user = User.Identity.Name;
                Intervention oldIntervention = interventionRepository.GetInterventionById(id);
                Intervention intervention = InterventionTranspose.UpdatedCreateInterventionViewModelToUpdatedIntervention(oldIntervention, createInterventionViewModel, user);

                bool interventionIsUpdated = interventionRepository.UpdatedIntervention(intervention);
                if (interventionIsUpdated)
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

        // GET: Intervention/Terminer
        public ActionResult Terminer(int id)
        {
            try
            {
                Intervention intervention = interventionRepository.GetInterventionById(id);
                Reclamation reclamation = reclamationRepository.GetReclamationById(intervention.Reclamation);
                CreateInterventionViewModel createInterventionViewModel = InterventionTranspose.InterventionToCreateInterventionViewModel(intervention, reclamation);
                return View(createInterventionViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // POST: Intervention/Terminer
        [HttpPost]
        public ActionResult Terminer(int id, CreateInterventionViewModel createInterventionViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(createInterventionViewModel);
                }
                string user = User.Identity.Name;
                Intervention oldIntervention = interventionRepository.GetInterventionById(id);
                Intervention intervention = InterventionTranspose.TerminerInterventionViewModelToterminerIntervention(oldIntervention, createInterventionViewModel, user);
                Reclamation reclamationById = reclamationRepository.GetReclamationById(oldIntervention.Reclamation);
                Materiel materielById = materielRepository.GetMaterielById(reclamationById.Materiel);
                bool interventionIsFinished = interventionRepository.FinishedIntervention(intervention);
                if (interventionIsFinished)
                {
                    Reclamation reclamationEtat = ReclamationTranspose.ChangeReclamationEtat(reclamationById, user, intervention.Etat);
                    bool reclamationIsChanged = reclamationRepository.ChangeReclamation(reclamationEtat);
                    if (reclamationIsChanged)
                    {
                        Materiel materielStatus = MaterielTranspose.ChangeMaterielStatut(materielById, user, "Non reclamé");
                        bool materielIsChanged = materielRepository.ChangeMateriel(materielStatus);
                        if (materielIsChanged)
                        {
                            return RedirectToAction("Finished");
                        }
                        else
                        {
                            throw new InvalidOperationException("Désolé");
                        }
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
        
        // GET: Intervention/Annuler
        public ActionResult Annuler(int id)
        {
            try
            {
                Intervention intervention = interventionRepository.GetInterventionById(id);
                Reclamation reclamation = reclamationRepository.GetReclamationById(intervention.Reclamation);
                InterventionViewModel interventionViewModel = InterventionTranspose.InterventionToInterventionViewModel(intervention, reclamation);
                return View(interventionViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
        // POST: Intervention/Annuler
        [HttpPost]
        public ActionResult Annuler(int id, InterventionViewModel interventionViewModel)
        {
            try
            {
                string user = User.Identity.Name;
                Intervention oldIntervention = interventionRepository.GetInterventionById(id);
                Intervention intervention = InterventionTranspose.AnnulerInterventionViewModelToAnnulerIntervention(oldIntervention, user);
                Reclamation reclamationById = reclamationRepository.GetReclamationById(oldIntervention.Reclamation);
                bool interventionIsCanceled = interventionRepository.CanceledIntervention(intervention);
                if (interventionIsCanceled)
                {
                    Reclamation reclamationEtat = ReclamationTranspose.ChangeReclamationEtat(reclamationById, user, "En attente");
                    bool reclamationIsChanged = reclamationRepository.ChangeReclamation(reclamationEtat);
                    if (reclamationIsChanged)
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


        // Static Reports (tous les materiels)
        public FileResult StaticReports()
        {
            byte[] file = interventionRepository.StaticReports();
            string filename = $"static_reports_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }


        // Static Report (une seul intervention)
        public FileResult StaticReport(int id)
        {
            byte[] file = interventionRepository.StaticReport();
            string filename = $"static_report_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Reports (tous les interventions)
        public FileResult DynamicReports()
        {
            List<Intervention> interventions = interventionRepository.GetInterventions();
            List<Reclamation> reclamations = reclamationRepository.GetReclamations();
            List<InterventionReport> interventionReports = InterventionTranspose.InterventionListToInterventionReportList(interventions, reclamations);
            byte[] file = interventionRepository.DynamicReports(interventionReports);
            string filename = $"ListeInterventions_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Report (une seul intervention)
        public FileResult DynamicReport(int id)
        {
            Intervention intervention = interventionRepository.GetInterventionById(id);
            Reclamation reclamation = reclamationRepository.GetReclamationById(intervention.Reclamation);
            InterventionReport interventionReport = InterventionTranspose.InterventionToInterventionReport(intervention, reclamation);
            byte[] file = interventionRepository.DynamicReport(interventionReport);
            string filename = $"DetailsIntervention_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

    }
    }
