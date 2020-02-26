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
        List<SocieteTierce> GetSocieteTierces();
        /// <summary>
        /// Returns societe tierce by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SocieteTierce GetSocieteTierceById(int id);
    }

      
}
