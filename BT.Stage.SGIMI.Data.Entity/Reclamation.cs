using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.Entity
{
    public class Reclamation
    {
        public int Id { get; set; }
        public string Materiel { get; set; }
        public string Date { get; set; }
        public string Probleme { get; set; }
        public string Commentaire { get; set; }
        public string Etat { get; set; }
        public int CreatedBy { get; set; }
    }
}
