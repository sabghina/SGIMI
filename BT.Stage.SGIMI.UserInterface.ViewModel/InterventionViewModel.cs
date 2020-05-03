using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class InterventionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }


        public string Nature { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string Date { get; set; }


        public string Etat { get; set; }

    
        public int Reclamation { get; set; }
        

        [RegularExpression(@"^[A - Z] +[a - zA - Z'\s]*$")]
        [Required(ErrorMessage = "Veuillez exprimer le problème constaté")]
        [MaxLength(100)]
        [Display(Name = " Problème Constaté")]
        public string ProblèmeConstaté { get; set; }



        [RegularExpression(@"^[A - Z] +[a - zA - Z'\s]*$")]
        [Required(ErrorMessage = "Veuillez exprimer les traveaux effectués")]
        [MaxLength(100)]
        [Display(Name = " Les traveaux effectués")]
        public string TraveauxEffectués { get; set; }


        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
