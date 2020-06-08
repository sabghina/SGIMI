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
    public class ChartReclamationController : Controller
    {
        readonly IReclamationRepository reclamationRepository;
        public ChartReclamationController(IReclamationRepository _reclamationRepository)
        {
            reclamationRepository = _reclamationRepository;
        }
        // GET: ChartReclamation
        public ActionResult Index()
        {
            List<Reclamation> reclamations = reclamationRepository.GetReclamations();
            var nbReclamationByDate = reclamations.GroupBy(Reclamation => Reclamation.CreatedDate)
                .Select(groupedReclamation => new { date = groupedReclamation.Key, dates = groupedReclamation.ToList() })
                .ToList();

            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var groupReclamation in nbReclamationByDate)
            {
                dataPoints.Add(new DataPoint(groupReclamation.date, groupReclamation.dates.Count()));
            }

            ViewBag.NombreReclamationParDate = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}