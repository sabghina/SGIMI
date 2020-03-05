using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class MaterielViewModel
    {
        public int Id { get; set; }
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
        public string Fournisseur { get; set; }
        public string CreatedBy { get; set; }
    }
}
