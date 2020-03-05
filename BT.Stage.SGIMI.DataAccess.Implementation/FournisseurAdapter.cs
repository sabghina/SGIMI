using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class FournisseurAdapter : IFournisseurAdapter
    {
        public bool CreateFournisseur(Fournisseur fournisseur)
        {
            // ajout in database
            return true;
        }

        public Fournisseur GetFournisseurById(int id)
        {
            // replace with database access
            Fournisseur fournisseur = new Fournisseur
            {
                Id = id,
                Nom = "Fournisseur" + id,
                Email = "fourniseuremail" + id,
                Telephone = "+216xxxxx",
                Fax = "7xxxxxx",
                Type = 'F',
                Adresse = "Rue xxxxxxxx",
                SiteWeb = "www.societe.com",
                CreatedBy = "user" + id + 1,
                CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = "admin",
                LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
                
               
            };

            return fournisseur;
        }

        public List<Fournisseur> GetFournisseurs()
        {
            // replace with databse access
            List<Fournisseur> fournisseurs = new List<Fournisseur>();
            for (int i = 1; i < 10; i++)
            {
                Fournisseur fournisseur = new Fournisseur
                {
                    Id = i,
                    Nom = "Fournisseur" + i,
                    Email = "fourniseuremail" + i,
                    Type = 'F',
                    Telephone = "+216xxxxx",
                    Fax = "7xxxxxx",
                    Adresse = "Rue xxxxxxxx",
                    SiteWeb = "www.fournisseur.com",
                    CreatedBy = "admin",
                    CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                    LastUpdatedBy = "admin",
                    LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
                   
                   
                };

                fournisseurs.Add(fournisseur);
            }

            return fournisseurs;
        }

        public bool UpdateFournisseur(Fournisseur fournisseur)
        {
            return true;
        }
    }
}
