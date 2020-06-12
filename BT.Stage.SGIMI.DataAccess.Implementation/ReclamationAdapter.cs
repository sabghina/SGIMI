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
    public class ReclamationAdapter : IReclamationAdapter
    {
        private readonly ISGIMIDbContext sGIMIDbContext;
        public ReclamationAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }

        public bool ChangeReclamation(Reclamation reclamationById)
        {
            sGIMIDbContext.Reclamations.AddOrUpdate(reclamationById);
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

        public bool CreateReclamation(Reclamation reclamation)
        {
            sGIMIDbContext.Reclamations.Add(reclamation);
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

        public Reclamation GetReclamationById(int id)
        {
            Reclamation reclamation = sGIMIDbContext.Reclamations.Find(id);
     
            return reclamation;
        }
        public List<Reclamation> GetReclamations()
        {
            // replace with databse access
            List<Reclamation> reclamations = sGIMIDbContext.Reclamations.ToList();

            return reclamations;
        }

        public bool UpdateReclamation(Reclamation reclamation)
        {
            sGIMIDbContext.Reclamations.AddOrUpdate(reclamation);
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
