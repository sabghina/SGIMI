using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BT.Stage.SGIMI.BusinessLogic.Implementation
{
    public class InterventionRepository : IInterventionRepository
    {
        readonly IInterventionAdapter interventionAdapter;
        public InterventionRepository(IInterventionAdapter _interventionAdapter)
        {
            interventionAdapter = _interventionAdapter;
        }
        public bool CreateIntervention(Intervention intervention)
        {
            // traitement
            return interventionAdapter.CreateIntervention(intervention);
        }
        public Intervention GetInterventionById(int id)
        {
            return interventionAdapter.GetInterventionById(id);
        }

        public List<Intervention> GetInterventions()
        {
            List<Intervention> interventions = interventionAdapter.GetInterventions();
            return interventions;
        }
        public bool UpdatedIntervention(Intervention intervention)
        {
            return interventionAdapter.UpdateIntervention(intervention);
        }
    }
}
