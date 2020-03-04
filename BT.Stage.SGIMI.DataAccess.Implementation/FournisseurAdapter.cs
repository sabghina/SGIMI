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
                Adresse = "Rue xxxxxxxx",
                SiteWeb = "www.societe.com",
                CreatedBy = "user" + id + 1 
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
                    Telephone = "+216xxxxx",
                    Fax = "7xxxxxx",
                    Adresse = "Rue xxxxxxxx",
                    SiteWeb = "www.fournisseur.com",
                    CreatedBy = "user" + i + 1
                };

                fournisseurs.Add(fournisseur);
            }

            return fournisseurs;
        }
    }
}
