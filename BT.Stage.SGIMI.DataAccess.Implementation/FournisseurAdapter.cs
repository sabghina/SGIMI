using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Implementation.DatabaseConnection;
using BT.Stage.SGIMI.DataAccess.Interface;
using BT.Stage.SGIMI.DataAccess.Interface.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class FournisseurAdapter : IFournisseurAdapter
    { 
        private readonly ISGIMIDbContext sGIMIDbContext;
        public FournisseurAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }

        public bool ArchiveFournisseur(Fournisseur fournisseur)
        {
            sGIMIDbContext.Fournisseurs.AddOrUpdate(fournisseur);
            Task<int> nbRowsAffected = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsAffected != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateFournisseur(Fournisseur fournisseur)
        {
            sGIMIDbContext.Fournisseurs.Add(fournisseur);
            Task<int> nbRowsAffected = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsAffected != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Fournisseur GetFournisseurById(int id)
        {
            Fournisseur fournisseur = sGIMIDbContext.Fournisseurs.Find(id);
            return fournisseur;
        }

        public List<Fournisseur> GetFournisseurs()
        {
            List<Fournisseur> listFournisseurs = sGIMIDbContext.Fournisseurs.ToList();
            List<Fournisseur> fournisseurs = new List<Fournisseur>();
            foreach (Fournisseur fournisseur in listFournisseurs)
            {
                if ((fournisseur.Etat == "Active")&&(fournisseur.Type == "F"))
                {
                    fournisseurs.Add(fournisseur);
                }
            }

            return fournisseurs;
        }

        public List<Fournisseur> GetArchivedFournisseurs()
        {
            List<Fournisseur> fournisseurs = sGIMIDbContext.Fournisseurs.ToList();
            List<Fournisseur> archivedfournisseurs = new List<Fournisseur>();
            foreach (Fournisseur fournisseur in fournisseurs)
            {
                if (fournisseur.Etat == "Archivé")
                {
                    archivedfournisseurs.Add(fournisseur);
                }
            }

            return archivedfournisseurs;
        }

        public string GetNameFournisseurById(int id)
        {
            Fournisseur fournisseur = sGIMIDbContext.Fournisseurs.Find(id);
            return fournisseur.Nom;
        }

        public bool UpdateFournisseur(Fournisseur fournisseur)
        {            
            sGIMIDbContext.Fournisseurs.AddOrUpdate(fournisseur);
            Task<int> nbRowsAffected = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsAffected != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ActiveFournisseur(Fournisseur fournisseur)
        {
            sGIMIDbContext.Fournisseurs.AddOrUpdate(fournisseur);
            Task<int> nbRowsAffected = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsAffected != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

      
    }
}
