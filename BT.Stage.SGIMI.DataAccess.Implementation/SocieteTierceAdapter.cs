using BT.Stage.SGIMI.Data.Entity;
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

    public class SocieteTierceAdapter : ISocieteTierceAdapter

    //database data

    {
        private readonly ISGIMIDbContext sGIMIDbContext;
        public SocieteTierceAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }

        public bool CreateSocieteTierce(Fournisseur societeTierce)
        {
            sGIMIDbContext.Fournisseurs.Add(societeTierce);
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

        public Fournisseur GetSocieteTierceById(int id)
        {
            Fournisseur societeTierce = sGIMIDbContext.Fournisseurs.Find(id);
            return societeTierce;
        }

        
        public List<Fournisseur> GetSocieteTierces()
        {
            List<Fournisseur> fournisseurs = sGIMIDbContext.Fournisseurs.ToList();
            List<Fournisseur> societeTierces = new List<Fournisseur>();

            foreach (Fournisseur societeTierce in fournisseurs)
            {
                if ((societeTierce.Etat == "Active") && (societeTierce.Type == "S"))
                {
                    societeTierces.Add(societeTierce);
                }
            }

            return societeTierces;
        }

        public string GetNameSocieteTierceById(int id)
        {
            Fournisseur societeTierce = sGIMIDbContext.Fournisseurs.Find(id);
            return societeTierce.Nom;
        }

        public bool UpdateSocieteTierce(Fournisseur societeTierce)
        {
            sGIMIDbContext.Fournisseurs.AddOrUpdate(societeTierce);
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

        public List<Fournisseur> GetArchivedSocieteTierces()
        {
            List<Fournisseur> fournisseurs = sGIMIDbContext.Fournisseurs.ToList();
            List<Fournisseur> archivedSocieteTierces = new List<Fournisseur>();

            foreach (Fournisseur societeTierce in fournisseurs)
            {
                if ((societeTierce.Etat == "Archivé") && (societeTierce.Type == "S"))
                {
                    archivedSocieteTierces.Add(societeTierce);
                }
            }

            return archivedSocieteTierces;
        }

        public bool ArchiveSocieteTierce(Fournisseur societeTierce)
        {
            sGIMIDbContext.Fournisseurs.AddOrUpdate(societeTierce);
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
