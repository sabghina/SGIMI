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
    public class AvisRepository : IAvisRepository
    {
        readonly IAvisAdapter avisAdapter;
        public AvisRepository(IAvisAdapter _avisAdapter)
        {
            avisAdapter = _avisAdapter;
        }
        public bool CreateAvis(Avis avis)
        {
            return avisAdapter.CreateAvis(avis);
        }

        public List<Avis> GetAvis()
        {
            List<Avis> aviss = avisAdapter.GetAvis();
            return aviss;
        }
    }
}
