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
            List<SocieteTierce> GetSocieteTierces();
            /// <summary>
            /// Return SocieteTierce by id.
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            SocieteTierce GetSocieteTierceById(int id);
        }
    }


