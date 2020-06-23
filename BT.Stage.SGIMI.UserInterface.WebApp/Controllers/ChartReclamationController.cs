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
        public ChartReclamationController(IReclamationRepository _reclamationRepository)
        {
            reclamationRepository = _reclamationRepository;
        }
        // GET: ChartReclamation
        public ActionResult Index()
        {
            string currentUser = User.Identity.Name;
            List<Reclamation> reclamations = reclamationRepository.GetUserReclamations(currentUser);
            var nbReclamationByMateriel = reclamations.GroupBy(Reclamation => Reclamation.Materiel)
                .Select(groupedReclamation => new { materiel = groupedReclamation.Key, materiels = groupedReclamation.ToList() })
                .ToList();

            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (var groupReclamation in nbReclamationByMateriel)
            {
                //dataPoints.Add(new DataPoint(groupReclamation.materiel, groupReclamation.materiels.Count()));
            }

            ViewBag.NombreReclamationPar = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}