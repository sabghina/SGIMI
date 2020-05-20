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

        public int Id { get; set; }

       
        [Required(ErrorMessage = "Veuillez saisir le nom du matériel")]
        [MaxLength(20)]
        [Display(Name = " Nom")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Veuillez saisir la marque du matériel")]
        [MaxLength(10)]
        [Display(Name = " Marque")]
        public string Marque { get; set; }

        
        [Required(ErrorMessage = "Veuillez saisir le modèle du matériel")]
        [MaxLength(10)]
        [Display(Name = " Modèle")]
        public string Modele { get; set; }

       
        [Required(ErrorMessage = "Veuillez saisir la référence du matériel")]
        [MaxLength(20)]
        [Display(Name = " Réference BT")]
        public string ReferenceBT { get; set; }

       
        public string NumeroDeSerie { get; set; }

        public string Fournisseur { get; set; }

        public IEnumerable<SelectListItem> Fournisseurs { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public string CreatedBy { get; set; }
    }
}
