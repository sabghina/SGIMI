using chart.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.WebApp.Controllers
{
	[Authorize]
    public class HomeController : Controller
    {
		public ActionResult Index()
		{
			List<DataPoint> dataPoints1 = new List<DataPoint>();

			dataPoints1.Add(new DataPoint("Service comptabilité", 25));
			dataPoints1.Add(new DataPoint("Service GRH", 13));
			dataPoints1.Add(new DataPoint("Service Informatique", 8));
			dataPoints1.Add(new DataPoint("Service Financier", 6.8));
			dataPoints1.Add(new DataPoint("Agences", 60));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints1);

			List<DataPoint> dataPoints2 = new List<DataPoint>();

			dataPoints2.Add(new DataPoint("Materiel en bon etat", 25));
			dataPoints2.Add(new DataPoint("Materiel en panne", 13));
			dataPoints2.Add(new DataPoint("Materiel changé", 8));
			dataPoints2.Add(new DataPoint("Materiel Non affecté", 6.8));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints2);

			List<DataPoint> dataPoints3 = new List<DataPoint>();
			dataPoints3.Add(new DataPoint("Siege ", 60));
			dataPoints3.Add(new DataPoint("Agence", 40));

			ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints3);
			return View();
		}
	}
}