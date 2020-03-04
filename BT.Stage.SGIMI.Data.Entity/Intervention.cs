using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.Entity
{
   public class Intervention
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Etat { get; set; }
        public int Reclamation { get; set; }
        public string CreatedBy { get; set; }
        
    }
}
