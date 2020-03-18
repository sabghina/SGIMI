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
                UniteGestion uniteGestion = UniteGestionTranspose.UpdatedUniteGestionViewModelToUpdatedUniteGestion(id, uniteGestionViewModel, user);

                bool uniteGestionIsUpdated = uniteGestionRepository.UpdatedUniteGestion(uniteGestion);
                if (uniteGestionIsUpdated)
                {
                    return RedirectToAction("Details", new
                    {
                        id = uniteGestion.Id
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
    }
}