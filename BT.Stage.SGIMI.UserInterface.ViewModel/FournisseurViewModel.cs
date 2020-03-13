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
        [MaxLength(30)]
        public string Nom { get; set; }
        [MaxLength(30)]
        public string Email { get; set; }
        [MaxLength(15)]
        public string Telephone { get; set; }
        [MaxLength(30)]
        public string Adresse { get; set; }
        [MaxLength(15)]
        public string Fax { get; set; }
        [MaxLength(30)]
        public string SiteWeb { get; set; }
        /// <summary>
        /// F: Fourniseur, S: SociétéTierce
        /// </summary>
        public TypeFournisseur Type { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedTime { get; set; }
        public string LastUpdatedDate { get; set; }
        public string LastUpdatedTime { get; set; }
        public object LastUpdatedBy { get; set; }
    }
}
