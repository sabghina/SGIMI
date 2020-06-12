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
        public List<Intervention> GetInterventions()
        {
            // replace with databse access
            List<Intervention> interventions = sGIMIDbContext.Interventions.ToList();
            List<Intervention> interventionsOnHold = new List<Intervention>();
            foreach (Intervention intervention in interventions)
            {
                if (intervention.Etat == "En cours")
                {
                    interventionsOnHold.Add(intervention);
                }
            }
            return interventionsOnHold;
        }
        public List<Intervention> GetFinishedInterventions()
        {
            List<Intervention> interventions = sGIMIDbContext.Interventions.ToList();
            List<Intervention> finishedInterventions = new List<Intervention>();
            foreach (Intervention intervention in interventions)
            {
                if (intervention.Etat == "Terminée")
                {
                    finishedInterventions.Add(intervention);
                }
            }

            return finishedInterventions;
        }

        public List<Intervention> GetCanceledInterventions()
        {
            List<Intervention> interventions = sGIMIDbContext.Interventions.ToList();
            List<Intervention> canceledInterventions = new List<Intervention>();
            foreach (Intervention intervention in interventions)
            {
                if (intervention.Etat == "Annulée")
                {
                    canceledInterventions.Add(intervention);
                }
            }

            return canceledInterventions;
        }

        public Intervention GetInterventionById(int id)
        {
            Intervention intervention = sGIMIDbContext.Interventions.Find(id);
       
            return intervention;
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

        public bool FinishedIntervention(Intervention intervention)
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

        public bool CanceledIntervention(Intervention intervention)
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

  
