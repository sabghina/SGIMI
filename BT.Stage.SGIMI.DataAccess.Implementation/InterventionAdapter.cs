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
        public Intervention GetInterventionById(int id)
        {
            // replace with database access
            Intervention intervention = new Intervention
            {
                Id = id,
                Type = "Intervention" + id,
                Date = "0" + id + "/0" + id + "/2020",
                //Exemple pour le test
                Etat = "En cours",
                Reclamation = id + 1,
                CreatedBy = id + 1
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
                    Date = "0" + i + "/0" + i + "/2020",
                    //Exemple pour le test
                    Etat = "En cours",
                    CreatedBy = i + 1
                };

                interventions.Add(intervention);
            }

            return interventions;
        }
    }
}

  
