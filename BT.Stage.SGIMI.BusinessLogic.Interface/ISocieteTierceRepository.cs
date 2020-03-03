using BT.Stage.SGIMI.Commun.Tools;
using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface ISocieteTierceRepository
    {

        /// <summary>
        /// Returns List SocieteTierce.
        /// </summary>
        /// <returns></returns>
        List<Fournisseur> GetSocieteTierces();
        /// <summary>
        /// Returns societe tierce .
        /// </summary>
        /// <param name="societeTierce"></param>
        /// <returns></returns>
        Fournisseur GetSocieteTierceById(int id);
        bool CreateSocieteTierce(Fournisseur societeTierce);
    }


}
