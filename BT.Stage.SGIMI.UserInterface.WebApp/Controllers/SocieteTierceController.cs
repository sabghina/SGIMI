﻿using BT.Stage.SGIMI.BusinessLogic.Interface;
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
            List<SocieteTierce> societeTierces = societeTierceRepository.GetSocieteTierces();

            // 2. transpose entity -> view model
            List<SocieteTierceViewModel> societeTierceViewModels = SocieteTierceTranspose.SocieteTierceListToSocieteTierceViewModelList(societeTierces);

            return View(societeTierceViewModels);
        }

        // GET: SocieteTierce/Details/5
        public ActionResult Details(int id)
        {
            SocieteTierce societeTierce = societeTierceRepository.GetSocieteTierceById(id);

            SocieteTierceViewModel societeTierceViewModel = SocieteTierceTranspose.SocieteTierceToSocieteTierceViewModel(societeTierce);
            return View(societeTierceViewModel);
        }

        // GET: SocieteTierce/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SocieteTierce/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SocieteTierce/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SocieteTierce/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
    }
}
