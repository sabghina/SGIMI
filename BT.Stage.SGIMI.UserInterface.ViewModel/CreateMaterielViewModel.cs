﻿using System;
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

        [RegularExpression(@"[0-9]{2}|0)([0-9]{9}|[0-9\-\s]{9,18})")]
        [Required(ErrorMessage = "Veuillez saisir le nom du fournisseur")]
        [MaxLength(30)]
        [Display(Name = " Num de Serie")]
        public int NumeroDeSerie { get; set; }
       
        public int Fournisseur { get; set; }
       
        public IEnumerable<SelectListItem> Fournisseurs { get; set; }
        public string CreatedBy { get; set; }
    }
}
