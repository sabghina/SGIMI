﻿using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Data.Entity;
using chart.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly IReclamationRepository reclamationRepository;
        readonly IMaterielRepository materielRepository;
        public HomeController(IReclamationRepository _reclamationRepository, IMaterielRepository _materielRepository)
        {
            reclamationRepository = _reclamationRepository;
            materielRepository = _materielRepository;
        }

        public ActionResult Index()
        {
            List<DataPoint> dataPoints1 = new List<DataPoint>();

            dataPoints1.Add(new DataPoint("Service comptabilité", 25));
            dataPoints1.Add(new DataPoint("Service GRH", 13));
            dataPoints1.Add(new DataPoint("Service Informatique", 8));
            dataPoints1.Add(new DataPoint("Service Financier", 6.8));
            dataPoints1.Add(new DataPoint("Agences", 60));

            ViewBag.ReclamationParService = JsonConvert.SerializeObject(dataPoints1);
            //----------------------------------------------------------------------------------------------
            List<Materiel> materiels = materielRepository.GetMateriels();
            var materielsByMarque = materiels.GroupBy(materiel => materiel.Marque)
                .Select(groupedMateriel => new { marque = groupedMateriel.Key, marques = groupedMateriel.ToList() })
                .ToList();

            List<DataPoint> dataPoints2 = new List<DataPoint>();
            foreach (var groupMateriel in materielsByMarque)
            {
                dataPoints2.Add(new DataPoint(groupMateriel.marque, groupMateriel.marques.Count()));
            }            

            ViewBag.EtatMateriel = JsonConvert.SerializeObject(dataPoints2);

            //----------------------------------------------------------------------------------------------

            List<DataPoint> dataPoints3 = new List<DataPoint>();
            dataPoints3.Add(new DataPoint("Siege ", 50));
            dataPoints3.Add(new DataPoint("Agence", 50));

            ViewBag.ReclamationParUniteGestion = JsonConvert.SerializeObject(dataPoints3);
            return View();
        }
    }
}