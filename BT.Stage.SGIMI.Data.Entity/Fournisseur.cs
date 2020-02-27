using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Data.Entity
{
    public class Fournisseur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// F: Fourniseur, S: Société 
        /// </summary>
        public char Type { get; set; }
        public string CreatedBy { get; set; }

    }
}
