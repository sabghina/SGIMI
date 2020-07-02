using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Interface
{
    public interface IAvisRepository
    {

        List<Avis> GetAvis();
        bool CreateAvis(Avis avis);
       

      
    }
}
