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
    public class MaterielAdapter : IMaterielAdapter
    {
        private readonly ISGIMIDbContext sGIMIDbContext;
        public MaterielAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }

        public Materiel GetMaterielById(int id)
        {
            Materiel materiel = sGIMIDbContext.Materiels.Find(id);

            return materiel;
        }
        public List<Materiel> GetMateriels()
        {
            List<Materiel> Listmateriels = sGIMIDbContext.Materiels.ToList();
            List<Materiel> materiels = new List<Materiel>();
            foreach (Materiel materiel in Listmateriels)
            {
                if (materiel.Etat == "Non affecté")
                {
                    materiels.Add(materiel);
                }
            }
      
            return materiels;
        }

        public bool UpdateMateriel(Materiel materiel)
        {
            sGIMIDbContext.Materiels.AddOrUpdate(materiel);
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

        public bool CreateMateriel(Materiel materiel)
        {
            sGIMIDbContext.Materiels.Add(materiel);
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
        public bool AffecterMateriel(Materiel materiel)
        {
            sGIMIDbContext.Materiels.AddOrUpdate(materiel);
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

        public string GetReferenceMaterielById(int id)
        {
            Materiel materiel = sGIMIDbContext.Materiels.Find(id);
            return materiel.ReferenceBT;
        }

        public List<Materiel> GetAffectedMateriels()
        {
            List<Materiel> Listmateriels = sGIMIDbContext.Materiels.ToList();
            List<Materiel> materiels = new List<Materiel>();
            foreach (Materiel materiel in Listmateriels)
            {
               if (materiel.Etat == "Affecte")
                {
                    materiels.Add(materiel);
                }
            }

            return materiels;
        }

        public bool RevokeMateriel(Materiel materiel)
        {
            sGIMIDbContext.Materiels.AddOrUpdate(materiel);
            Task<int> nbRowsRevoked = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsRevoked != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ArchivedMateriel(Materiel materiel)
        {
            sGIMIDbContext.Materiels.AddOrUpdate(materiel);
            Task<int> nbRowsArchived = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsArchived != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Materiel> GetArchivedMateriels()
        {
            List<Materiel> Listmateriels = sGIMIDbContext.Materiels.ToList();
            List<Materiel> materiels = new List<Materiel>();
            foreach (Materiel materiel in Listmateriels)
            {
                if (materiel.Etat == "Supprimé")
                {
                    materiels.Add(materiel);
                }
            }

            return materiels;
        }
    }
}

