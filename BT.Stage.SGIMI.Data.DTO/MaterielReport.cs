using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.DTO
{
    public class MaterielReport
    {
        public string Nom { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public string ReferenceBT { get; set; }
        public string NumeroDeSerie { get; set; }
        public string Fournisseur { get; set; }
        public string Agent { get; set; }
        public string Etat { get; set; }
        public string Statut { get; set; }

        public string CreatedBy { get; set; }
        public string DateContrat { get; set; }

        public string AffectedBy { get; set; }
        public string DateAffectation { get; set; }

        public string RevokedBy { get; set; }
        public string DateElimination { get; set; }

        public string ArchivedBy { get; set; }
        public string DateArchive { get; set; }

        public string LastUpdatedBy { get; set; }
        public string DateModification { get; set; }

    }
}
