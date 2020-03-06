using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface ISocieteTierceAdapter
    {
        /// <summary>
        /// Returns List SocieteTierce.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetSocieteTierces();
        /// <summary>
        /// Return SocieteTierce by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Fournisseur GetSocieteTierceById(int id);
        /// <summary>
        /// Create new SocieteTierce
        /// </summary>
        /// <param name="societeTierce"></param>
        /// <returns></returns>
        bool CreateSocieteTierce(Fournisseur societeTierce);
        bool UpdateSocieteTierce(Fournisseur societeTierce);
    }
}


