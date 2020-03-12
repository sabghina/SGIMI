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
    public class MaterielRepository : IMaterielRepository
    {
        readonly IMaterielAdapter materielAdapter;
        public MaterielRepository(IMaterielAdapter _materielAdapter)
        {
            materielAdapter = _materielAdapter;
        }
        public Materiel GetMaterielById(int id)
        {
            return materielAdapter.GetMaterielById(id);
        }

        public List<Materiel> GetMateriels()
        {
            List<Materiel> materiels = materielAdapter.GetMateriels();
            return materiels;
        }

        public bool UpdatedMateriel(Materiel materiel)
        {
            return materielAdapter.UpdateMateriel(materiel);
        }

        bool IMaterielRepository.CreateMateriel(Materiel materiel)
        {
            return materielAdapter.CreateMateriel(materiel);
        }
    }
}
