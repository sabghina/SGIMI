using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Data.Entity;
using chart.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.WebApp.Controllers
{
    [Authorize]
    public class ChartReclamationController : Controller
    {
        readonly IReclamationRepository reclamationRepository;
        readonly IInterventionRepository interventionRepository;
        readonly IMaterielRepository materielRepository;
        public ChartReclamationController(IReclamationRepository _reclamationRepository,
            IMaterielRepository _materielRepository, IInterventionRepository _interventionRepository)
        {
            reclamationRepository = _reclamationRepository;
            materielRepository = _materielRepository;
            interventionRepository = _interventionRepository;
        }


        // GET: ChartReclamation
        public ActionResult Index()
        {
            //Liste des reclamations
            List<Reclamation> reclamationsOnHold = reclamationRepository.GetReclamations();
            List<Reclamation> reclamationsInProgress = reclamationRepository.GetInProgressReclamations();
            List<Reclamation> reclamationsCanceled = reclamationRepository.GetCanceledReclamations();
            List<Reclamation> reclamationsFinished = reclamationRepository.GetFinishedReclamations();
            List<Reclamation> reclamations = reclamationsOnHold;
            foreach (Reclamation reclamation in reclamationsInProgress)
            {
                reclamations.Add(reclamation);
            }
            foreach (Reclamation reclamation in reclamationsCanceled)
            {
                reclamations.Add(reclamation);
            }
            foreach (Reclamation reclamation in reclamationsFinished)
            {
                reclamations.Add(reclamation);
            }
            //Nombre des reclamations par etat
            var nbReclamationByEtat = reclamations.GroupBy(Reclamation => Reclamation.Etat)
            .Select(groupedReclamation => new { etat = groupedReclamation.Key, etats = groupedReclamation.ToList() }).ToList();
            //Nombre des reclamations par date
            var nbReclamationByDate = reclamations.GroupBy(Reclamation => Reclamation.CreatedDate)
                .Select(groupedReclamation => new { date = groupedReclamation.Key, dates = groupedReclamation.ToList() })
                .ToList();

            // Liste des reclamations par date
            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var groupReclamation in nbReclamationByDate)
            {
                dataPoints.Add(new DataPoint(groupReclamation.date, groupReclamation.dates.Count()));
            }
            //Liste des reclamations par etats
            List<DataPoint> dataPoints2 = new List<DataPoint>();
            foreach (var groupReclamation in nbReclamationByEtat)
            {
                dataPoints2.Add(new DataPoint(groupReclamation.etat, groupReclamation.etats.Count()));
            }

            ViewBag.NombreReclamationParDate = JsonConvert.SerializeObject(dataPoints);
            ViewBag.NombreReclamationParEtat = JsonConvert.SerializeObject(dataPoints2);
            return View();
        }
    }
}
