using BT.Stage.SGIMI.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Interface
{
    public interface IAvisAdapter
    {
        bool CreateAvis(Avis avis);
        List<Avis> GetAvis();
    }
}
