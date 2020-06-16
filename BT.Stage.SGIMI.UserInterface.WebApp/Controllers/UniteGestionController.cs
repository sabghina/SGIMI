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
    public class UniteGestionController : Controller
    {
        readonly IUniteGestionRepository uniteGestionRepository;
        public UniteGestionController(IUniteGestionRepository _uniteGestionRepository)
        {
            uniteGestionRepository = _uniteGestionRepository;
        }
        // GET: UniteGestion
        public ActionResult Index()
        {
            // 1.get service list uniteGestion
            List<UniteGestion> uniteGestions = uniteGestionRepository.GetUniteGestions();

            // 2. transpose entity -> view model
            List<UniteGestionViewModel> uniteGestionViewModels = UniteGestionTranspose.UniteGestionListToUniteGestionViewModelList(uniteGestions);

            return View(uniteGestionViewModels);
        }

        // GET: UniteGestion/Details/5
        public ActionResult Details(int id)
        {
            UniteGestion uniteGestion = uniteGestionRepository.GetUniteGestionById(id);

            UniteGestionViewModel uniteGestionViewModel = UniteGestionTranspose.UniteGestionToUniteGestionViewModel(uniteGestion);
            return View(uniteGestionViewModel);
        }

        // GET: UniteGestion/Create
        public ActionResult Create()
        {
            UniteGestionViewModel uniteGestionViewModel = new UniteGestionViewModel();
            return View(uniteGestionViewModel);
        }

        // POST: Fournisseur/Create
        [HttpPost]
        public ActionResult Create(UniteGestionViewModel uniteGestionViewModel)
        {
            try
            {
                // controle existance email
                //ModelState.AddModelError("Email", "Email existe");
                // controle
                if (!ModelState.IsValid)
                {
                    return View(uniteGestionViewModel);
                }
                // TODO: Add insert logic here
                string user = User.Identity.Name;
               
                UniteGestion uniteGestion = UniteGestionTranspose.CreateUniteGestionViewModelToUniteGestion(uniteGestionViewModel, user);

                bool uniteGestionIsCreated = uniteGestionRepository.CreateUniteGestion(uniteGestion);
                if (uniteGestionIsCreated)
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

        // GET: UniteGestion/Edit/5
        public ActionResult Edit(int id)
        {
            UniteGestion uniteGestion = uniteGestionRepository.GetUniteGestionById(id);
            UniteGestionViewModel uniteGestionViewModel = UniteGestionTranspose.UniteGestionToUniteGestionViewModel(uniteGestion);
            return View(uniteGestionViewModel);
        }

        // POST: UniteGestion/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UniteGestionViewModel uniteGestionViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(uniteGestionViewModel);
                }
                // TODO: Add update logic here
                string user = User.Identity.Name;
                UniteGestion oldUniteGestion = uniteGestionRepository.GetUniteGestionById(id);
                UniteGestion uniteGestion = UniteGestionTranspose.UpdatedUniteGestionViewModelToUpdatedUniteGestion(oldUniteGestion,uniteGestionViewModel, user);

                bool uniteGestionIsUpdated = uniteGestionRepository.UpdatedUniteGestion(uniteGestion);
                if (uniteGestionIsUpdated)
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

        // GET: UniteGestion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UniteGestion/Delete/5
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

        // Static Reports (tous les unités de gestion)
        public FileResult StaticReports()
        {
              byte[] file = uniteGestionRepository.StaticReports();
              string filename = $"ListeUnitesGestions_{DateTime.Now}.pdf";
              return File(file, "application/pdf", filename);
        }


         // Static Report (une seule unités de gestion)
        public FileResult StaticReport(int id)
        {
              byte[] file = uniteGestionRepository.StaticReport();
              string filename = $"static_report_{id}_{DateTime.Now}.pdf";
              return File(file, "application/pdf", filename);
        }

        // Dynamic Reports (tous les unités de gestion)
        public FileResult DynamicReports()
            {
                List<UniteGestion> uniteGestions = uniteGestionRepository.GetUniteGestions();
                List<UniteGestionReport> uniteGestionReports = UniteGestionTranspose.UniteGestionListToUniteGestionReportList(uniteGestions);
                byte[] file = uniteGestionRepository.DynamicReports(uniteGestionReports);
                string filename = $"ListeUnitesGestions_{DateTime.Now}.pdf";
                return File(file, "application/pdf", filename);
            }

        // Dynamic Report (une seule unités de gestion)
         public FileResult DynamicReport(int id)
         {
                UniteGestion uniteGestion = uniteGestionRepository.GetUniteGestionById(id);
                UniteGestionReport uniteGestionReport = UniteGestionTranspose.UniteGestionToUniteGestionReport(uniteGestion);
                byte[] file = uniteGestionRepository.DynamicReport(uniteGestionReport);
                string filename = $"DetailsUniteGestion_{id}_{DateTime.Now}.pdf";
                return File(file, "application/pdf", filename);
         }
        }
    }
