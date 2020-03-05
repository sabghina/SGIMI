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
        [MaxLength(30)]
        public string Nom { get; set; }
        [Required]
        [MaxLength(15)]
        public string Marque { get; set; }
        [Required]
        [MaxLength(10)]
        public string Modele { get; set; }
        [Required]
        [MaxLength(7)]
        public string ReferenceBT { get; set; }
        [Required]
        [MaxLength(7)]
        public int NumeroDeSerie { get; set; }
        [Required]
        public int Fournisseur { get; set; }
        [Required]
        public IEnumerable<SelectListItem> Fournisseurs { get; set; }
        public string CreatedBy { get; set; }
    }
}
