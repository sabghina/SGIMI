using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.DTO
{
    public class ReclamationReport
    {
        public string Materiel { get; set; }
        public string Probleme { get; set; }
        public string Commentaire { get; set; }
        public string Etat { get; set; }
        public string UniteGestion { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreation { get; set; }
        public string LastUpdatedBy { get; set; }
        public string DateModification { get; set; }

    }
}
