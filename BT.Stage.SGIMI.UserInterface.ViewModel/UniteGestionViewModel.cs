using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
   public class UniteGestionViewModel
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Fax { get; set; }
        public string Type { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }

    }
}
