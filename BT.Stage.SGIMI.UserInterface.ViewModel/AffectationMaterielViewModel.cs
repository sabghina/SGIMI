using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class AffectationMaterielViewModel
    {  
        public int Id { get; set; }
        public string Etat { get; set; }
        public string Agent { get; set; }
        public IEnumerable<SelectListItem> Agents { get; set; }

        public string AffectedBy { get; set; }
        public string AffectedDate { get; set; }
        public string AffectedTime { get; set; }

   
    }
}

    
