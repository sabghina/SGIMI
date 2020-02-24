using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface IFournisseurRepository
    {
        /// <summary>
        /// Returns List Fournissuers.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetFournisseurs();
        /// <summary>
        /// Returns fournisseur by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Fournisseur GetFournisseurById(int id);
    }
}
