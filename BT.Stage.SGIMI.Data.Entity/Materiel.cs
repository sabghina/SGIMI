using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.Entity
{
    class Materiel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Reference { get; set; }
        //doit etre changer par un attribut significatif
        public int Fournisseur { get; set; }
        public int CreatedBy { get; set; }
    }
}
