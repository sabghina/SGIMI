using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.Entity
{
    public class Materiel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string ReferenceBT { get; set; }
        public int NumeroDeSerie { get; set; }
        public int Fournisseur { get; set; }
        public string Created { get; set; }
        public string CreatedTime { get; set; }
        public string LastUpdated { get; set; }
        public string LastUpdatedTime  { get; set; }
        public string LastUpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
