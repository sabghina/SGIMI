﻿using BT.Stage.SGIMI.BusinessLogic.Implementation;
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
            FournisseurViewModel fournisseurViewModel = new FournisseurViewModel();
            return View(fournisseurViewModel);
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(FournisseurViewModel fournisseurViewModel)
        {
            try
            {
                // controle existance email
                //ModelState.AddModelError("Email", "Email existe");
                // controle
                if (!ModelState.IsValid)
                {
                    return View(fournisseurViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
                Fournisseur fournisseur = FournisseurTranspose.FournisseurViewModelToFournisseur(fournisseurViewModel, user);

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
            Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(id);
            FournisseurViewModel fournisseurViewModel = FournisseurTranspose.FournisseurToFournisseurViewModel(fournisseur);
            return View(fournisseurViewModel);
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
                // TODO: Add update logic here
                string user = User.Identity.Name;
                Fournisseur fournisseur = FournisseurTranspose.UpdatedFournisseurViewModelToUpdatedFournisseur(id, fournisseurViewModel, user);

                bool fournisseurIsUpdated = fournisseurRepository.UpdatedFournisseur(fournisseur);
                if (fournisseurIsUpdated)
                {
                    return RedirectToAction("Details", new
                    {
                        id = fournisseur.Id
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
            string filename = $"dynamic_reports_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Report (un seul fournisseur)
        public FileResult DynamicReport(int id)
        {
            Fournisseur fournisseur = fournisseurRepository.GetFournisseurById(id);
            FournisseurReport fournisseurReport = FournisseurTranspose.FournisseurToFournisseurReport(fournisseur);
            byte[] file = fournisseurRepository.DynamicReport(fournisseurReport);
            string filename = $"dynamic_report_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }
    }
}


