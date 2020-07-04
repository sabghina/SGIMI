using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Implementation.DatabaseConnection;
using BT.Stage.SGIMI.UserInterface.WebApp.Models;
using chart.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace BT.Stage.SGIMI.UserInterface.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        readonly IReclamationRepository reclamationRepository;
        readonly IInterventionRepository interventionRepository;
        readonly IMaterielRepository materielRepository;
        public HomeController(IReclamationRepository _reclamationRepository, IMaterielRepository _materielRepository, IInterventionRepository _interventionRepository)
        {
            reclamationRepository = _reclamationRepository;
            materielRepository = _materielRepository;
            interventionRepository = _interventionRepository;
        }
 
        public ActionResult Index()
        {
            //ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            //List<ApplicationUser> users = applicationDbContext.Users.ToList();

            //SGIMIDbContext sGIMIDbContext = new SGIMIDbContext();
            //List<ApplicationUser> _users = sGIMIDbContext.Users.ToList();

            //Liste des reclamations
            List<Reclamation> reclamationsOnHold = reclamationRepository.GetReclamations();
            List<Reclamation> reclamationsInProgress = reclamationRepository.GetInProgressReclamations();
            List<Reclamation> reclamationsCanceled = reclamationRepository.GetCanceledReclamations();
            List<Reclamation> reclamationsFinished = reclamationRepository.GetFinishedReclamations();
            List<Reclamation> reclamations = reclamationsOnHold;
            foreach(Reclamation reclamation in reclamationsInProgress)
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

            /////////////////////////////////////////////////////////////////////////////////////////////////////
            List<Intervention> interventionsInProgress = interventionRepository.GetInterventions();
            List<Intervention> intereventionsCanceled = interventionRepository.GetCanceledInterventions();
            List<Intervention> interventionsFinished = interventionRepository.GetFinishedInterventions();
            List<Intervention> interventions = interventionsInProgress;

            foreach (Intervention intervention in intereventionsCanceled)
            {
                interventions.Add(intervention);
            }
            foreach (Intervention intervention in interventionsFinished)
            {
                interventions.Add(intervention);
            }
            //Nombre des interventions par date
            var nbInterventionByDate = interventions.GroupBy(Intervention => Intervention.CreatedDate)
            .Select(groupedIntervention => new { date = groupedIntervention.Key, dates = groupedIntervention.ToList() }).ToList();

            //Nombre des intervention par etat
            var nbInterventionByEtat = interventions.GroupBy(Intervention => Intervention.Etat)
            .Select(groupedIntervention => new { etat = groupedIntervention.Key, etats = groupedIntervention.ToList() }).ToList();

            //Liste des interventions par dates
            List<DataPoint> dataPoints3 = new List<DataPoint>();
            foreach (var groupIntervention in nbInterventionByDate)
            {
                dataPoints3.Add(new DataPoint(groupIntervention.date, groupIntervention.dates.Count()));
            }

            //Liste des interventions par etats
            List<DataPoint> dataPoints4 = new List<DataPoint>();
            foreach (var groupIntervention in nbInterventionByEtat)
            {
                dataPoints4.Add(new DataPoint(groupIntervention.etat, groupIntervention.etats.Count()));
            }

            ViewBag.NombreInterventionParDate = JsonConvert.SerializeObject(dataPoints3);
            ViewBag.NombreInterventionParEtat = JsonConvert.SerializeObject(dataPoints4);
            return View();


        }
    }
}