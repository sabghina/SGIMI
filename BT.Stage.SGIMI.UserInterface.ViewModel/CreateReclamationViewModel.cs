using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class CreateReclamationViewModel
    {
        public int Id { get; set; }
        public int Materiel { get; set; }
        public string Etat { get; set; }

        [Required(ErrorMessage = "Veuillez exprimer votre problème")]
        [Display(Name = "Problème à réclamer")]
        public string Probleme { get; set; }
        [Required(ErrorMessage = "Veuillez saisir un commentaire")]
        [Display(Name = "Commentaire")]
        public string Commentaire { get; set; }
        
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }

        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }
        
        public string UniteGestion { get; set; }
        public IEnumerable<SelectListItem> UniteGestions { get; set; }
    }
}
