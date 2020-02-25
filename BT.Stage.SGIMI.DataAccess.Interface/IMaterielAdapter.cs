using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface IMaterielAdapter
    {
        /// <summary>
        /// Returns List Materiels.
        /// </summary>
        /// <returns></returns>
        List<Materiel> GetMateriels();
        /// <summary>
        /// Return materiel by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Materiel GetMaterielById(int id);
    }
}
