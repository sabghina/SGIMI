using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BT.Stage.SGIMI.Data.DTO
{
    public class FournisseurReport
    {
        
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Adresse { get; set; }
        public string SiteWeb { get; set; }
        public string DateContrat { get; set; }
    }
}
