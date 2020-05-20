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
   public class InterventionAdapter : IInterventionAdapter

    {
        private readonly ISGIMIDbContext sGIMIDbContext;
        public InterventionAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }
        public bool CreateIntervention(Intervention intervention)
        {
            sGIMIDbContext.Interventions.Add(intervention);
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

        public Intervention GetInterventionById(int id)
        {
            Intervention intervention = sGIMIDbContext.Interventions.Find(id);
       
            return intervention;
        }
        public List<Intervention> GetInterventions()
        {
            // replace with databse access
            List<Intervention> interventions = sGIMIDbContext.Interventions.ToList();
            return interventions;
        }
        public bool UpdateIntervention(Intervention intervention)
        {
            sGIMIDbContext.Interventions.AddOrUpdate(intervention);
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

  
