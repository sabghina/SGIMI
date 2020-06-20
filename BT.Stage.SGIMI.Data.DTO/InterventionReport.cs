using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.DTO
{
    public class InterventionReport
    {
        public string Reclamation { get; set; }
        public string Etat { get; set; }
        public string Nature { get; set; }
        public string Type { get; set; }
        public string ProblemeConstate { get; set; }
        public string TraveauxEffectues { get; set; }
        public string CreatedBy { get; set; }
        public string DateCreation { get; set; }
        public string LastUpdatedBy { get; set; }
        public string DateModification { get; set; }
    }
}
