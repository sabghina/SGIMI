using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{

    public class SocieteTierceAdapter : ISocieteTierceAdapter
    {
        public bool CreateSocieteTierce(Fournisseur societeTierce)
        {
            // ajout in database
            return true;
        }
        public Fournisseur GetSocieteTierceById(int id)
        {
            // replace with database access
            Fournisseur societeTierce = new Fournisseur
            {
                Id = id,
                Nom = "Societe Tierce" + id,
                Email = "SocieteTierceemail" + id,
                Telephone = "+216xxxxx",
                Fax = "7xxxxxx",
                Adresse = "Rue xxxxxxxx",
                SiteWeb = "www.societe.com",
                CreatedBy = "user" + id + 1,
                CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = "admin",
                LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
            };

            return societeTierce;
        }

        public List<Fournisseur> GetSocieteTierces()
        {
            // replace with databse access
            List<Fournisseur> societeTierces = new List<Fournisseur>();
            for (int i = 1; i < 10; i++)
            {
                Fournisseur societeTierce = new Fournisseur
                {
                    Id = i,
                    Nom = "Societe Tierce" + i,
                    Email = "SocieteTierceemail" + i,
                    Telephone = "+216xxxxx",
                    Fax = "7xxxxxx",
                    Adresse = "Rue xxxxxxxx",
                    SiteWeb = "www.societe.com",
                    CreatedBy = "user" + i + 1,
                    CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                    LastUpdatedBy = "admin",
                    LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
                };

                societeTierces.Add(societeTierce);
            }
            return societeTierces;
        }

        
    }
}
