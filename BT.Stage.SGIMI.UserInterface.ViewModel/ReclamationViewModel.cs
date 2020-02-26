using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class ReclamationViewModel
    {
        public int Id { get; set; }
        public string Materiel { get; set; }
        public string Date { get; set; }
        //doit etre changer par un attribut significatif
        public string Etat { get; set; }
        public int CreatedBy { get; set; }
    }
}
