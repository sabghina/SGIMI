using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class CreateMaterielViewModel
    {        
        [Required]
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string ReferenceBT { get; set; }
        public int NumeroDeSerie { get; set; }
        public int Fournisseur { get; set; }
        public IEnumerable<SelectListItem> Fournisseurs { get; set; }
        public string CreatedBy { get; set; }
    }
}
