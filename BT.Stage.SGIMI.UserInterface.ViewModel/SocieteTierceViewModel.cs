using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class SocieteTierceViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public char Type { get; set; }
    }
}
