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
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string ReferenceBT { get; set; }
        public string NumeroDeSerie { get; set; }
        public string Fournisseur { get; set; }
        public string Etat { get; set; }
        public string Agent { get; set; }

        public string AffectedBy { get; set; }
        public string AffectedDate { get; set; }
        public string AffectedTime { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }

        public string LastUpdatedBy { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }
  
    }
}
