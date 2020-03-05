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
                    Text = fournisseur.Nom + " (" + fournisseur.Type + ")"
                }).AsEnumerable(), "Id", "Text");

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
                        Text = fournisseur.Nom + " (" + fournisseur.Type + ")"
                    }).AsEnumerable(), "Id", "Text");
                    createMatrielViewModel.Fournisseurs = fournisseursSelectListItem;

                    return View(createMatrielViewModel);
                }
                string user = User.Identity.Name;
                Materiel materiel = MaterielTranspose.CreateMaterielViewModelToMateriel(createMatrielViewModel);

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
            return View();
        }

        // POST: Materiel/Edit/5
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
    }
}
