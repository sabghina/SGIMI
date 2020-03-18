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
    public class UniteGestionRepository : IUniteGestionRepository
    {
        readonly IUniteGestionAdapter uniteGestionAdapter;
        public UniteGestionRepository(IUniteGestionAdapter _uniteGestionAdapter)
        {
            uniteGestionAdapter = _uniteGestionAdapter;
        }

        public bool CreateUniteGestion(UniteGestion uniteGestion)
        {
            // traitement
            return uniteGestionAdapter.CreateUniteGestion(uniteGestion);
        }

        public UniteGestion GetUniteGestionById(int id)
        {
            return uniteGestionAdapter.GetUniteGestionById(id);
        }

        public List<UniteGestion> GetUniteGestions()
        {
            List<UniteGestion> uniteGestions = uniteGestionAdapter.GetUniteGestions();
            return uniteGestions;
        }

        public bool UpdatedUniteGestion(UniteGestion uniteGestion)
        {
            return uniteGestionAdapter.UpdateUniteGestion(uniteGestion);
        }

        public bool UpdateUniteGestion(UniteGestion uniteGestion)
        {
            throw new NotImplementedException();
        }
    }
}
