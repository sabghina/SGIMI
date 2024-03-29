﻿using BT.Stage.SGIMI.BusinessLogic.Implementation;
using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Commun.Tools;
using BT.Stage.SGIMI.Data.DTO;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Implementation.DatabaseConnection;
using BT.Stage.SGIMI.DataAccess.Interface.DatabaseConnection;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.WebApp.Controllers
{
    [Authorize]
    public class MaterielController : Controller
    {
        readonly IMaterielRepository materielRepository;
        readonly IFournisseurRepository fournisseurRepository;
        readonly ISocieteTierceRepository societeTierceRepository;
        readonly IUniteGestionRepository uniteGestionRepository;
        private readonly IEnumerable<SelectListItem> nameUsers;

        public MaterielController(
            IMaterielRepository _materielRepository,
            IFournisseurRepository _fournisseurRepository, ISocieteTierceRepository _societeTierceRepository, IUniteGestionRepository _uniteGestionRepository, IEnumerable<SelectListItem> _nameUsers)
        {
            materielRepository = _materielRepository;
            fournisseurRepository = _fournisseurRepository;
            societeTierceRepository = _societeTierceRepository;
            uniteGestionRepository = _uniteGestionRepository;
            nameUsers = _nameUsers;
        }

        // GET: Materiel non affecté
        public ActionResult Index()
        {
            // 1.get service list materiel 
            List<Materiel> materiels = materielRepository.GetMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            // 2. transpose entity -> view model
            List<MaterielViewModel> materielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(materiels,fournisseurs);

            return View(materielViewModels);
        }
        // GET: Materiel affecté
        public ActionResult Affected()
        {
            // 1.get service list materiel 
            List<Materiel> affectedMateriels = materielRepository.GetAffectedMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            // 2. transpose entity -> view model
            List<MaterielViewModel> affectedMaterielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(affectedMateriels, fournisseurs);

            return View(affectedMaterielViewModels);
        }

        // GET: Materiel supprimé
        public ActionResult Archived()
        {
            // 1.get service list materiel 
            List<Materiel> archivedMateriels = materielRepository.GetArchivedMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            // 2. transpose entity -> view model
            List<MaterielViewModel> archivedMaterielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(archivedMateriels, fournisseurs);

            return View(archivedMaterielViewModels);
        }
        // GET: Materiel reclamé
        public ActionResult Complained()
        {
            // 1.get service list materiel 
            List<Materiel> complainedMateriels = materielRepository.GetComplainedMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            // 2. transpose entity -> view model
            List<MaterielViewModel> archivedMaterielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(complainedMateriels, fournisseurs);

            return View(archivedMaterielViewModels);
        }
        // GET: Materiel reclamé
        public ActionResult ComplainedUser()
        {
            // 1.get service list materiel 
            string currentUser = User.Identity.Name;
            List<Materiel> complainedUserMateriels = materielRepository.GetComplainedUserMateriels(currentUser);
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            // 2. transpose entity -> view model
            List<MaterielViewModel> archivedMaterielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(complainedUserMateriels, fournisseurs);

            return View(archivedMaterielViewModels);
        }
        // GET: Materiel reclamé
        public ActionResult UserMateriels()
        {
            // 1.get service list materiel 
            string currentUser = User.Identity.Name;
            List<Materiel> userMateriels = materielRepository.GetUserMateriels(currentUser);
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);
            }
            // 2. transpose entity -> view model
            List<MaterielViewModel> userMaterielsViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(userMateriels, fournisseurs);

            return View(userMaterielsViewModels);
        }

        // GET: Materiel/Details/5
        public ActionResult Details(int id)
        {
            Materiel materiel = materielRepository.GetMaterielById(id);
            Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(materiel.Fournisseur);
            MaterielViewModel materielViewModel = MaterielTranspose.MaterielToMaterielViewModel(materiel,fournisseur);
            return View(materielViewModel);
        }

        // GET: Materiel/Create
        public ActionResult Create()
        {
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            IEnumerable<SelectListItem> fournisseursSelectListItem = new SelectList(fournisseurs.Select(
                fournisseur => new
                {
                    Id = fournisseur.Id,
                    Text = fournisseur.Nom 
                }).AsEnumerable(), "Id", "Text");

            CreateMaterielViewModel createMaterielViewModel = new CreateMaterielViewModel
            {
                Fournisseurs = fournisseursSelectListItem
            };
            return View(createMaterielViewModel);
        }

        // POST: Materiel/Create
        [HttpPost]
        public ActionResult Create(CreateMaterielViewModel createMatrielViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
                    List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
                    foreach (Fournisseur societeTierce in societeTierces)
                    {
                        fournisseurs.Add(societeTierce);

                    }
                    IEnumerable<SelectListItem> fournisseursSelectListItem = new SelectList(fournisseurs.Select(
                    fournisseur => new
                    {
                        Id = fournisseur.Id,
                        Text = fournisseur.Nom 
                    }).AsEnumerable(), "Id", "Text");
                    createMatrielViewModel.Fournisseurs = fournisseursSelectListItem;

                    return View(createMatrielViewModel);

                }
                string user = User.Identity.Name;
                Materiel materiel = MaterielTranspose.CreateMaterielViewModelToMateriel(createMatrielViewModel, user);

                bool materielIsCreated = materielRepository.CreateMateriel(materiel);
                if (materielIsCreated)
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
                throw new InvalidOperationException("sorry you can't insert this item"); ;
            }
        }

        // GET: Materiel/Edit/5
        public ActionResult Edit(int id)
        {
            Materiel materiel = materielRepository.GetMaterielById(id);
            CreateMaterielViewModel createMaterielViewModel = MaterielTranspose.MaterielToCreateMaterielViewModel(materiel);
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            IEnumerable<SelectListItem> fournisseursSelectListItem = new SelectList(fournisseurs.Select(
                fournisseur => new
                {
                    Id = fournisseur.Id,
                    Text = fournisseur.Nom
                }).AsEnumerable(), "Text", "Text");

            createMaterielViewModel.Fournisseurs = fournisseursSelectListItem;
            
            return View(createMaterielViewModel);

        }

        // POST: Materiel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CreateMaterielViewModel createMaterielViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
                    List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
                    foreach (Fournisseur societeTierce in societeTierces)
                    {
                        fournisseurs.Add(societeTierce);

                    }
                    IEnumerable<SelectListItem> fournisseursSelectListItem = new SelectList(fournisseurs.Select(
                    fournisseur => new
                    {
                        Id = fournisseur.Id,
                        Text = fournisseur.Nom
                    }).AsEnumerable(), "Text", "Text");
                    createMaterielViewModel.Fournisseurs = fournisseursSelectListItem;
                    return View(createMaterielViewModel);
                }
                // TODO: Add update logic here
                string user = User.Identity.Name;
                Materiel oldMateriel = materielRepository.GetMaterielById(id);
                Materiel materiel = MaterielTranspose.UpdatedMaterielViewModelToUpdatedMateriel(oldMateriel, createMaterielViewModel, user);

                bool materielIsUpdated = materielRepository.UpdatedMateriel(materiel);
                if (materielIsUpdated)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    throw new InvalidOperationException("invalid");
                }


            }
            catch
            {
                return View();
            }
        }
        // GET: Materiel/Filtrer/5
        public ActionResult Filtrer(int id)
        {
            List<UniteGestion> uniteGestions = uniteGestionRepository.GetUniteGestions();
            IEnumerable<SelectListItem> uniteGestionsSelectListItem = new SelectList(uniteGestions.Select(
                uniteGestion => new
                {
                    Id = uniteGestion.Id,
                    Text = uniteGestion.Nom
                }).AsEnumerable(), "Text", "Text");

            AffectationMaterielViewModel affectationMaterielViewModel = new AffectationMaterielViewModel
            {
                UniteGestions = uniteGestionsSelectListItem,
            };
            
            affectationMaterielViewModel.Id = id;
            return View(affectationMaterielViewModel);

        }

        // POST: Materiel/Filtrer
        [HttpPost]
        public ActionResult Filtrer(int id,AffectationMaterielViewModel affectationMaterielViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(affectationMaterielViewModel);
                }

                Materiel oldMateriel = materielRepository.GetMaterielById(id);
                Materiel materiel = MaterielTranspose.FiltrerMaterielViewModelToMateriel(oldMateriel, affectationMaterielViewModel);

                bool materielIsCreated = materielRepository.FiltrerMateriel(materiel);
                if (materielIsCreated)
                {
                    return RedirectToAction("Affecter",new { Id = id });
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

        // GET: Materiel/Affecter/5
        public ActionResult Affecter(int id)
        {
            SGIMIDbContext sGIMIDbContext = new SGIMIDbContext();
            List<ApplicationUser> _users = sGIMIDbContext.Users.ToList();
            Materiel materiel = materielRepository.GetMaterielById(id);
            foreach (ApplicationUser applicationUser in _users)
            {
                UniteGestion uniteGestion = uniteGestionRepository.GetUniteGestionById(applicationUser.Unite);

                if (uniteGestion.Nom == materiel.UniteGestion)
                {

                    IEnumerable<SelectListItem> nameUsers = new SelectList(_users.Select(
                agent => new
                {
                    Id = agent.Email,
                    Text = agent.UserName
                }).AsEnumerable(), "Text", "Id");
                    //IEnumerable<SelectListItem> nameUsers = new SelectList(new List<string> { "admin@bt.com", "admin@bt.com" }).AsEnumerable(),;
                }
            }
                AffectationMaterielViewModel affectationMaterielViewModel = new AffectationMaterielViewModel
                {
                    Agents = nameUsers,
                };
            affectationMaterielViewModel.Id = id;
            return View(affectationMaterielViewModel);

        }

        // POST: Materiel/Affecter
        [HttpPost]
        public ActionResult Affecter(int id, AffectationMaterielViewModel affectationMaterielViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(affectationMaterielViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
                Materiel oldMateriel = materielRepository.GetMaterielById(id);
                Materiel materiel = MaterielTranspose.AffectationMaterielViewModelToMateriel(oldMateriel, affectationMaterielViewModel, user);

                bool materielIsCreated = materielRepository.AffecterMateriel(materiel);
                if (materielIsCreated)
                {
                    return RedirectToAction("Affected");
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


        // GET: Materiel/Retirer
        public ActionResult Retirer(int id)
        {
            try
            {
                Materiel materiel = materielRepository.GetMaterielById(id);
                Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(materiel.Fournisseur);
                MaterielViewModel materielViewModel = MaterielTranspose.MaterielToMaterielViewModel(materiel,fournisseur);
                return View(materielViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Materiel/Retirer
        [HttpPost]
        public ActionResult Retirer(int id,     MaterielViewModel materielViewModel)
        {
            try
            {
                string user = User.Identity.Name;
                Materiel oldMateriel = materielRepository.GetMaterielById(id);
                Materiel materiel = MaterielTranspose.RetirerMaterielViewModelToRetirerMateriel(oldMateriel, user);
                bool materielIsRevoked = materielRepository.RevokeMateriel(materiel);
                if (!materielIsRevoked)
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

        // GET: Materiel/Archiver
        public ActionResult Archiver(int id)
        {
            try
            {
                Materiel materiel = materielRepository.GetMaterielById(id);
                Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(materiel.Fournisseur);
                MaterielViewModel materielViewModel = MaterielTranspose.MaterielToMaterielViewModel(materiel,fournisseur);
                return View(materielViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: Materiel/Archiver
        [HttpPost]
        public ActionResult Archiver(int id, MaterielViewModel materielViewModel)
        {
            try
            {
                string user = User.Identity.Name;
                Materiel oldMateriel = materielRepository.GetMaterielById(id);
                Materiel materiel = MaterielTranspose.ArchiverMaterielViewModelToArchiverMateriel(oldMateriel, user);
                bool materielIsArchived = materielRepository.ArchivedMateriel(materiel);
                if (!materielIsArchived)
                {
                    throw new Exception("oops");
                }
                return RedirectToAction("Archived");
            }
            catch
            {
                throw;
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
        // Static Reports (tous les materiels)
        public FileResult StaticReports()
        {
            byte[] file = materielRepository.StaticReports();
            string filename = $"static_reports_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }


        // Static Report (un seul materiel)
        public FileResult StaticReport(int id)
        {
            byte[] file = materielRepository.StaticReport();
            string filename = $"static_report_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Reports (tous les materiels)
        public FileResult DynamicReportsNoAffected()
        {
            List<Materiel> materiels = materielRepository.GetMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            List<MaterielReport> materielReports = MaterielTranspose.MaterielListToMaterielReportList(materiels, fournisseurs);
            byte[] file = materielRepository.DynamicReportsNoAffected(materielReports);
            string filename = $"Liste_Des_Materiels_Non_Affecté{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        public FileResult DynamicReportsAffected()
        {
            List<Materiel> materiels = materielRepository.GetAffectedMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            List<MaterielReport> materielReports = MaterielTranspose.MaterielListToMaterielReportList(materiels, fournisseurs);
            byte[] file = materielRepository.DynamicReportsAffected(materielReports);
            string filename = $"Liste_Des_Materiels_Affecté{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        public FileResult DynamicReportsUserAffected()
        {
            string currentUser = User.Identity.Name;
            List<Materiel> materiels = materielRepository.GetUserMateriels(currentUser);
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            List<MaterielReport> materielReports = MaterielTranspose.MaterielListToMaterielReportList(materiels, fournisseurs);
            byte[] file = materielRepository.DynamicReportsAffected(materielReports);
            string filename = $"Liste_Des_Materiels_Affecté_User{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        public FileResult DynamicReportsArchived()
        {
            List<Materiel> materiels = materielRepository.GetArchivedMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            List<MaterielReport> materielReports = MaterielTranspose.MaterielListToMaterielReportList(materiels, fournisseurs);
            byte[] file = materielRepository.DynamicReportsArchived(materielReports);
            string filename = $"Liste_Des_Materiels_Archivés{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        public FileResult DynamicReportsComplained()
        {
            List<Materiel> materiels = materielRepository.GetComplainedMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            List<MaterielReport> materielReports = MaterielTranspose.MaterielListToMaterielReportList(materiels, fournisseurs);
            byte[] file = materielRepository.DynamicReportsComplained(materielReports);
            string filename = $"Liste_Des_Materiels_Réclamés{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        public FileResult DynamicReportsComplainedUser()
        {
            string currentUser = User.Identity.Name;
            List<Materiel> materiels = materielRepository.GetComplainedUserMateriels(currentUser);
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseursActive();
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            foreach (Fournisseur societeTierce in societeTierces)
            {
                fournisseurs.Add(societeTierce);

            }
            List<MaterielReport> materielReports = MaterielTranspose.MaterielListToMaterielReportList(materiels, fournisseurs);
            byte[] file = materielRepository.DynamicReportsComplained(materielReports);
            string filename = $"Liste_Des_Materiels_Réclamés_User{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Report (un seul materiel)
        public FileResult DynamicReport(int id)
        {
            Materiel materiel = materielRepository.GetMaterielById(id);
            Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(materiel.Fournisseur);
            MaterielReport materielReport = MaterielTranspose.MaterielToMaterielReport(materiel, fournisseur);
            byte[] file = materielRepository.DynamicReport(materielReport);
            string filename = $"ContratMateriel_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }
    }
}
