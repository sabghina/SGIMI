using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BT.Stage.SGIMI.UserInterface.WebApp.Models
{
    public class DateFilter
    {
		public string datedebut { get; set; }
		public string datefin { get; set; }
		public DateFilter(string datedebut, string datefin)
		{
			this.datedebut = datedebut;
			this.datefin = datefin;
		}
	}
}