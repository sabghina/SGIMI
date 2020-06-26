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
    public class SocieteTierceController : Controller
    {
        readonly ISocieteTierceRepository societeTierceRepository;
        public SocieteTierceController(ISocieteTierceRepository _societeTierceRepository)
        {
            societeTierceRepository = _societeTierceRepository;
        }

        // GET: SocieteTierce
        public ActionResult Index()
        {
            // 1.get service list societeTierce 
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();

            // 2. transpose entity -> view model
            List<SocieteTierceViewModel> societeTierceViewModels = SocieteTierceTranspose.FournisseurListToSocieteTierceViewModelList(societeTierces);

            return View(societeTierceViewModels);
        }
        // GET: Fournisseur Archived
        public ActionResult Archived()
        {
            // 1.get service list societeTierce 
            List<Fournisseur> archivedSocieteTierces = societeTierceRepository.GetArchivedSocieteTierces();
            // 2. transpose entity -> view model
            List<SocieteTierceViewModel> archivedSocieteTierceViewModels = SocieteTierceTranspose.FournisseurListToSocieteTierceViewModelList(archivedSocieteTierces);

            return View(archivedSocieteTierceViewModels);
        }

        // GET: SocieteTierce/Details/5
        public ActionResult Details(int id)
        {
            Fournisseur societeTierce = societeTierceRepository.GetSocieteTierceById(id);

            SocieteTierceViewModel societeTierceViewModel = SocieteTierceTranspose.FournisseurToSocieteTierceViewModel(societeTierce);
            return View(societeTierceViewModel);
        }

        // GET: SocieteTierce/Create
        public ActionResult Create()
        {

            SocieteTierceViewModel societeTierceViewModel = new SocieteTierceViewModel();
            return View(societeTierceViewModel);
        }

        // POST: SocieteTierce/Create
        [HttpPost]
        public ActionResult Create(SocieteTierceViewModel societeTierceViewModel)
        {
            try
            {
                // controle existance email
                //ModelState.AddModelError("Email", "Email existe");
                // controle
                if (!ModelState.IsValid)
                {
                    return View(societeTierceViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
                Fournisseur societeTierce = SocieteTierceTranspose.CreateSocieteTierceViewModelToSocieteTierce(societeTierceViewModel, user);

                bool societeTierceIsCreated = societeTierceRepository.CreateSocieteTierce(societeTierce);
                if (societeTierceIsCreated)
                    return RedirectToAction("Index");
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

        // GET: SocieteTierce/Edit/5
        public ActionResult Edit(int id)
        {
            Fournisseur societeTierce = societeTierceRepository.GetSocieteTierceById(id);
            SocieteTierceViewModel societeTierceViewModel = SocieteTierceTranspose.FournisseurToSocieteTierceViewModel(societeTierce);
            return View(societeTierceViewModel);
        }

        // POST: SocieteTierce/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SocieteTierceViewModel societeTierceViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(societeTierceViewModel);
                }
                // TODO: Add update logic here
                string user = User.Identity.Name;
                Fournisseur oldSocieteTierce = societeTierceRepository.GetSocieteTierceById(id);
                Fournisseur societeTierce = SocieteTierceTranspose.UpdatedSocieteTierceViewModelToUpdatedSocieteTierce(oldSocieteTierce,societeTierceViewModel, user);

                bool societeTierceIsUpdated = societeTierceRepository.UpdatedSocieteTierce(societeTierce);
                if (societeTierceIsUpdated)
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

        // GET: SocieteTierce/Archiver/5
        public ActionResult Archiver(int id)
        {
            try
            {
                Fournisseur societeTierce = societeTierceRepository.GetSocieteTierceById(id);
                SocieteTierceViewModel societeTierceViewModel = SocieteTierceTranspose.FournisseurToSocieteTierceViewModel(societeTierce);
                return View(societeTierceViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: SocieteTierce/Archiver/5
        [HttpPost]
        public ActionResult Archiver(int id, SocieteTierceViewModel societeTierceViewModel)
        {
            try
            {
                string user = User.Identity.Name;
                Fournisseur oldSocieteTierce = societeTierceRepository.GetSocieteTierceById(id);
                Fournisseur societeTierce = SocieteTierceTranspose.ArchiverSocieteTierceViewModelToArchiverFournisseur(oldSocieteTierce, user);
                bool societeTierceIsArchived = societeTierceRepository.ArchivedSocieteTierce(societeTierce);
                if (!societeTierceIsArchived)
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
        // GET: SocieteTierce/Activer/5
        public ActionResult Activer(int id)
        {
            try
            {
                Fournisseur societeTierce = societeTierceRepository.GetSocieteTierceById(id);
                SocieteTierceViewModel societeTierceViewModel = SocieteTierceTranspose.FournisseurToSocieteTierceViewModel(societeTierce);
                return View(societeTierceViewModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST: SocieteTierce/Activer/5
        [HttpPost]
        public ActionResult Activer(int id, FournisseurViewModel fournisseurViewModel)
        {
            try
            {
                string user = User.Identity.Name;
                Fournisseur oldSocieteTierce = societeTierceRepository.GetSocieteTierceById(id);
                Fournisseur societeTierce = SocieteTierceTranspose.ActiverSocieteTierceViewModelToActiverFournisseur(oldSocieteTierce, user);
                bool societeTierceIsActivated = societeTierceRepository.ActivatedSocieteTierce(societeTierce);
                if (!societeTierceIsActivated)
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

        // GET: SocieteTierce/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SocieteTierce/Delete/5
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


        // Static Reports (tous les st tierces)
        public FileResult StaticReports()
        {
            byte[] file = societeTierceRepository.StaticReports();
            string filename = $"static_reports_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }


        // Static Report (une seule st)
        public FileResult StaticReport(int id)
        {
            byte[] file = societeTierceRepository.StaticReport();
            string filename = $"static_report_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Reports (tous les st tierces)
        public FileResult DynamicReports()
        {
            List<Fournisseur> societeTierces = societeTierceRepository.GetSocieteTierces();
            List<SocieteTierceReport> societeTierceReports = SocieteTierceTranspose.SocieteTierceListToSocieteTierceReportList(societeTierces);
            byte[] file = societeTierceRepository.DynamicReports(societeTierceReports);
            string filename = $"Liste_SocieteTierce_Actives{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        //Societe Tierce Archived Dynamic Reports
        public FileResult DynamicReportsArchived()
        {
            List<Fournisseur> societeTierces = societeTierceRepository.GetArchivedSocieteTierces();
            List<SocieteTierceReport> societeTierceReports = SocieteTierceTranspose.SocieteTierceListToSocieteTierceReportList(societeTierces);
            byte[] file = societeTierceRepository.DynamicReports(societeTierceReports);
            string filename = $"Liste_SocieteTierce_Archivées{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }
        // Dynamic Report (une seule st tierce)
        public FileResult DynamicReport(int id)
        {
            Fournisseur societeTierce = societeTierceRepository.GetSocieteTierceById(id);
            SocieteTierceReport societeTierceReport = SocieteTierceTranspose.SocieteTierceToSocieteTierceReport(societeTierce);
            byte[] file = societeTierceRepository.DynamicReport(societeTierceReport);
            string filename = $"Contrat_SocieteTierce_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }
    }
    } 
