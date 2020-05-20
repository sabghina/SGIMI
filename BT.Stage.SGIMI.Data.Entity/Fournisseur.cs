using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BT.Stage.SGIMI.Data.Entity
{
    public class Fournisseur
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

        [RegularExpression(@"(\+00216[0-9]{2}|0)([0-9]{9}|[0-9\-\s]{9,18})")]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "Longueur non valide")]
        [Required(ErrorMessage = "Veuillez saisir le numéro de téléphone du fournisseur")]
        [MaxLength(15)]
        [Display(Name = " Téléphone")]
        public string Telephone { get; set; }


        [Required(ErrorMessage = "Veuillez saisir l'adresse du fournisseur")]
        [MaxLength(30)]
        [Display(Name = " Adresse")]
        public string Adresse { get; set; }

        [RegularExpression(@"(\+00216[0-9]{2}|0)([0-9]{9}|[0-9\-\s]{9,18})")]
        [Required(ErrorMessage = "Veuillez saisir le fax du fournisseur")]
        [MaxLength(15)]
        [Display(Name = " Fax")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Veuillez saisir le site web du fournisseur")]
        [MaxLength(30)]
        [Display(Name = "Site Web")]
        public string SiteWeb { get; set; }

        /// <summary>
        /// F: Fourniseur, S: SociétéTierce
        /// </summary>
        public char Type { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }
        public object LastUpdatedBy { get; set; }
    }
}
