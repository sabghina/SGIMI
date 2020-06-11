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

        // GET: Materiel non affecté
        public ActionResult Index()
        {
            // 1.get service list materiel 
            List<Materiel> materiels = materielRepository.GetMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();

            // 2. transpose entity -> view model
            List<MaterielViewModel> materielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(materiels,fournisseurs);

            return View(materielViewModels);
        }
        // GET: Materiel affecté
        public ActionResult Affected()
        {
            // 1.get service list materiel 
            List<Materiel> affectedMateriels = materielRepository.GetAffectedMateriels();
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
            // 2. transpose entity -> view model
            List<MaterielViewModel> affectedMaterielViewModels = MaterielTranspose.MaterielListToMaterielViewModelList(affectedMateriels, fournisseurs);

            return View(affectedMaterielViewModels);
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
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
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
                    List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
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
            List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
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
                    List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
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
        // GET: Materiel/Affecter/5
        public ActionResult Affecter(int id)
        {

            AffectationMaterielViewModel affectationMaterielViewModel = new AffectationMaterielViewModel();
            affectationMaterielViewModel.Id = id;
            return View(affectationMaterielViewModel);

            //Materiel materiel = materielRepository.GetMaterielById(id);
            //CreateMaterielViewModel createMaterielViewModel = MaterielTranspose.MaterielToCreateMaterielViewModel(materiel);
            //List<Fournisseur> fournisseurs = fournisseurRepository.GetFournisseurs();
            //IEnumerable<SelectListItem> fournisseursSelectListItem = new SelectList(fournisseurs.Select(
            //    fournisseur => new
            //    {
            //        Id = fournisseur.Id,
            //        Text = fournisseur.Nom
            //    }).AsEnumerable(), "Text", "Text");

            //createMaterielViewModel.Fournisseurs = fournisseursSelectListItem;

            //return View(createMaterielViewModel);
        }

        // POST: Materiel/Affecter
        [HttpPost]
        public ActionResult Affecter(int id,AffectationMaterielViewModel affectationMaterielViewModel)
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
                Materiel oldMateriel = materielRepository.GetMaterielById(id);
                Materiel materiel = MaterielTranspose.AffectationMaterielViewModelToMateriel(oldMateriel, affectationMaterielViewModel, user);

                bool materielIsCreated = materielRepository.AffecterMateriel(materiel);
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
