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
        public string Etat { get; set; }

        public string CreatedBy { get; set; }
        public string DateContrat { get; set; }

        public string ArchivedBy { get; set; }
        public string DateArchive { get; set; }
        
        public string ActivatedBy { get; set; }
        public string DateActivation { get; set; }

        public string LastUpdatedBy { get; set; }
        public string DateModification { get; set; }
    }
}
