using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using BT.Stage.SGIMI.DataAccess.Interface.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class AvisAdapter : IAvisAdapter
    {
        private readonly ISGIMIDbContext sGIMIDbContext;
        public AvisAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }
        public bool CreateAvis(Avis avis)
        {
            throw new NotImplementedException();
        }

        public List<Avis> GetAvis()
        {
            throw new NotImplementedException();
        }
    }
}
