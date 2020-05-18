using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
   public class InterventionAdapter : IInterventionAdapter

    {
        public bool CreateIntervention(Intervention intervention)
        {
            return true;
        }

        public Intervention GetInterventionById(int id)
        {
            // replace with database access
            Intervention intervention = new Intervention
            {
                Id = id,
                Type = "Intervention" + id,
                Date = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                //Exemple pour le test
                Etat = "En cours",
                Reclamation = id + 1,
                ProblemeConstate = "Probleme"+ id,
                TraveauxEffectues = "traveaux" + id,
                CreatedBy = "user" + id + 1,
                CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                LastUpdatedBy = "admin",
                LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
            };

            return intervention;
        }
        public List<Intervention> GetInterventions()
        {
            // replace with databse access
            List<Intervention> interventions = new List<Intervention>();
            for (int i = 1; i < 10; i++)
            {
                Intervention intervention = new Intervention
                {
                    Id = i,
                    Type = "Type" + i,
                    Nature = "Nature"+i,
                    Date = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    //Exemple pour le test
                    Etat = "En cours",
                    Reclamation = i+1,
                    ProblemeConstate = "Probleme" + i,
                    TraveauxEffectues = "traveaux" + i,
                    CreatedBy = "user" + i + 1,
                    CreatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    CreatedTime = DateTime.Now.ToString("HH:mm:ss"),
                    LastUpdatedBy = "admin",
                    LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
                };

                interventions.Add(intervention);
            }

            return interventions;
        }
        public bool UpdateIntervention(Intervention intervention)
        {
            return true;
        }
    }
}

  
