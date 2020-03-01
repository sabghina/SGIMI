using BT.Stage.SGIMI.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.UserInterface.ViewModel
{
    public class FournisseurViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        public string Email { get; set; }
        /// <summary>
        /// F: Fourniseur, S: SociétéTierce
        /// </summary>
        public TypeFournisseur Type { get; set; }
        public string CreatedBy { get; set; }

    }
}
