using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface IUniteGestionAdapter
    {
        /// <summary>
        /// Returns List Fournissuers.
        /// </summary>
        /// <returns></returns>
        List<UniteGestion> GetUniteGestions();
        /// <summary>
        /// Return UniteGestion by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UniteGestion GetUniteGestionById(int id);
        /// <summary>
        /// Create new UniteGestion
        /// </summary>
        /// <param name="fournisseur"></param>
        /// <returns></returns>
        bool CreateUniteGestion(UniteGestion uniteGestion);
        bool UpdateUniteGestion(UniteGestion uniteGestion);
    }
}