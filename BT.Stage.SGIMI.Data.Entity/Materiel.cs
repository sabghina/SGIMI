using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BT.Stage.SGIMI.Data.Entity
{
    public class Materiel
    {
        public int Id { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "Veuillez saisir le nom du matériel")]
        [MaxLength(20)]
        [Display(Name = " Nom")]
        public string Nom { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "Veuillez saisir la marque du matériel")]
        [MaxLength(10)]
        [Display(Name = " Marque")]
        public string Marque { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z'\s]*$")]
        [Required(ErrorMessage = "Veuillez saisir le modèle du matériel")]
        [MaxLength(10)]
        [Display(Name = " Modèle")]
        public string Modele { get; set; }


        [Required(ErrorMessage = "Veuillez saisir la référence du matériel")]
        [MaxLength(20)]
        [Display(Name = " Réference BT")]
        public string ReferenceBT { get; set; }

        
        public string NumeroDeSerie { get; set; }
        public int Fournisseur { get; set; }
        public string Etat { get; set; }
        public string Agent { get; set; }

        public string AffectedBy { get; set; }
        public string AffectedDate { get; set; }
        public string AffectedTime { get; set; }

        public string RevokedBy { get; set; }
        public string RevokedDate { get; set; }
        public string RevokedTime { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }

        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }


       

        
    }
}
