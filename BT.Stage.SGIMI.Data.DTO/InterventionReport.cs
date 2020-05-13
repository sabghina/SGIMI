using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.DTO
{
    class InterventionReport
    {
        public string Date { get; set; }
        public string Etat { get; set; }
        public int Reclamation { get; set; }
        public string ProblèmeConstaté { get; set; }
        public string TraveauxEffectués { get; set; }
    }
}
