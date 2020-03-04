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
    public class ReclamationRepository : IReclamationRepository
    {
        readonly IReclamationAdapter reclamationAdapter;
        public ReclamationRepository(IReclamationAdapter _reclamationAdapter)
        {
            reclamationAdapter = _reclamationAdapter;
        }

        public bool CreateReclamation(Reclamation reclamation)
        {
            return reclamationAdapter.CreateReclamation(reclamation);
        }

        public Reclamation GetReclamationById(int id)
        {
            return reclamationAdapter.GetReclamationById(id);
        }

        public List<Reclamation> GetReclamations()
        {
            List<Reclamation> reclamations = reclamationAdapter.GetReclamations();
            return reclamations;
        }
    }
}
