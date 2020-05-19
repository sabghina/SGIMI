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
            List<Fournisseur> fournisseurs = sGIMIDbContext.Fournisseurs.ToList();

            return fournisseurs;
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
    }
}
