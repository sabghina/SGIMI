using BT.Stage.SGIMI.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class FournisseurViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Veuillez saisir le nom du fournisseur")]
        [MaxLength(30)]
        [Display(Name = " Nom")]
        public string Nom { get; set; }

        
        [Required(ErrorMessage = "Veuillez saisir le mail")]
        [MaxLength(30)]
        [Display(Name = " Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(8, ErrorMessage = "Longueur non valide")]
        [Required(ErrorMessage = "Veuillez saisir le numéro de téléphone du fournisseur")]
        [MaxLength(8)]
        [Display(Name = " Téléphone")]
        public string Telephone { get; set; }


        [Required(ErrorMessage = "Veuillez saisir l'adresse du fournisseur")]
        [MaxLength(30)]
        [Display(Name = " Adresse")]
        public string Adresse { get; set; }

        [StringLength(8, ErrorMessage = "Longueur non valide")]
        [Required(ErrorMessage = "Veuillez saisir le fax du fournisseur")]
        [MaxLength(8)]
        [Display(Name = " Fax")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Veuillez saisir le site web du fournisseur")]
        [MaxLength(30)]
        [Display(Name = "Site Web")]
        public string SiteWeb { get; set; }

        /// <summary>
        /// F: Fourniseur, S: SociétéTierce
        /// </summary>
        public string Type { get; set; }
        public string Etat { get; set; }

        public string ArchivedBy { get; set; }
        public string ArchivedDate { get; set; }
        public string ArchivedTime { get; set; }

        public string ActivatedBy { get; set; }
        public string ActivatedDate { get; set; }
        public string ActivatedTime { get; set; }


        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }

        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }
        
    }
}
