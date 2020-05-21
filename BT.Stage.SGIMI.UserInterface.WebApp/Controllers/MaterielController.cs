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
    public class MaterielController : Controller
    {
        readonly IMaterielRepository materielRepository;
        readonly IFournisseurRepository fournisseurRepository;
        public MaterielController(
            IMaterielRepository _materielRepository,
            IFournisseurRepository _fournisseurRepository)
        {
            materielRepository = _materielRepository;
            fournisseurRepository = _fournisseurRepository;
        }

        // GET: Materiel
        public ActionResult Index()
        {
            // 1.get service list materiel 
            List<Materiel> materiels = materielRepository.GetMateriels();

            // 2. transpose entity -> view model
            List<MaterielViewModel> materielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(materiels);

            return View(materielViewModels);
        }

        // GET: Materiel/Details/5
        public ActionResult Details(int id)
        {
            Materiel materiel = materielRepository.GetMaterielById(id);

            MaterielViewModel materielViewModel = MaterielTranspose.MaterielToMaterielViewModel(materiel);
            return View(materielViewModel);
        }

        // GET: Materiel/Create
        public ActionResult Create()
        {
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
            IEnumerable<SelectListItem> fournisseursSelectListItem = new SelectList(fournisseurs.Select(
                fournisseur => new
                {
                    Id = fournisseur.Id,
                    Text = fournisseur.Nom 
                }).AsEnumerable(), "Text", "Text");

            CreateMaterielViewModel createMatrielViewModel = new CreateMaterielViewModel
            {
                Fournisseurs = fournisseursSelectListItem
            };
            return View(createMatrielViewModel);
        }

        // POST: Materiel/Create
        [HttpPost]
        public ActionResult Create(CreateMaterielViewModel createMatrielViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
                    IEnumerable<SelectListItem> fournisseursSelectListItem = new SelectList(fournisseurs.Select(
                    fournisseur => new
                    {
                        Id = fournisseur.Id,
                        Text = fournisseur.Nom 
                    }).AsEnumerable(), "Text", "Text");
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
                    return View(createMaterielViewModel);
                }
                // TODO: Add update logic here
                string user = User.Identity.Name;
                Materiel materiel = MaterielTranspose.UpdatedMaterielViewModelToUpdatedMateriel(createMaterielViewModel, user);

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

        public ActionResult Affecter(int id)
        {

            AffectationMaterielViewModel affectationMaterielViewModel = new AffectationMaterielViewModel();
            affectationMaterielViewModel.Id = id;
            return View(affectationMaterielViewModel);


        }

        // POST: Materiel/Affectr
        [HttpPost]
        public ActionResult Affecter(AffectationMaterielViewModel affectationMaterielViewModel)
        {
            try
            {
                // controle existance email
                //ModelState.AddModelError("Email", "Email existe");
                // controle
                if (!ModelState.IsValid)
                {
                    return View(affectationMaterielViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
                Materiel materiel = MaterielTranspose.AffectationMaterielViewModelToMateriel(affectationMaterielViewModel, user);

                bool materielIsCreated = materielRepository.CreateMateriel(materiel);
                if (materielIsCreated)
                {
                    return RedirectToAction("Details", new
                    {
                        id = materiel.Id
                    });
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
        public FileResult DynamicReports()
        {
            List<Materiel> materiels = materielRepository.GetMateriels();
            List<MaterielReport> materielReports = MaterielTranspose.MaterielListToMaterielReportList(materiels);
            byte[] file = materielRepository.DynamicReports(materielReports);
            string filename = $"dynamic_reports_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }

        // Dynamic Report (un seul materiel)
        public FileResult DynamicReport(int id)
        {
            Materiel materiel = materielRepository.GetMaterielById(id);
            MaterielReport materielReport = MaterielTranspose.MaterielToMaterielReport(materiel);
            byte[] file = materielRepository.DynamicReport(materielReport);
            string filename = $"ContratMateriel_{id}_{DateTime.Now}.pdf";
            return File(file, "application/pdf", filename);
        }
    }
}
