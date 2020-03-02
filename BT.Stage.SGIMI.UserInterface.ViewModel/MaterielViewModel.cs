using System;
using System.Collections.Generic;
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
        public int NumeroDeSerie { get; set; }
        public string Fournisseur { get; set; }
        public int CreatedBy { get; set; }
    }
}
