using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using BT.Stage.SGIMI.DataAccess.Interface.DatabaseConnection;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class UniteGestionAdapter : IUniteGestionAdapter
    {
        private readonly ISGIMIDbContext sGIMIDbContext;
        public UniteGestionAdapter(ISGIMIDbContext _sGIMIDbContext)
        {
            sGIMIDbContext = _sGIMIDbContext;
        }


        public bool CreateUniteGestion(UniteGestion uniteGestion)
        {
            sGIMIDbContext.UniteGestions.Add(uniteGestion);
            Task<int> nbRowsAffected = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsAffected != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public UniteGestion GetUniteGestionById(int id)
        {
          
            UniteGestion uniteGestion = sGIMIDbContext.UniteGestions.Find(id);
          
            return uniteGestion;
        }

        public List<UniteGestion> GetUniteGestions()
        {
            List<UniteGestion> uniteGestions = sGIMIDbContext.UniteGestions.ToList();

            return uniteGestions;
        }

        public bool UpdateUniteGestion(UniteGestion uniteGestion)
        {
            sGIMIDbContext.UniteGestions.AddOrUpdate(uniteGestion);
            Task<int> nbRowsAffected = sGIMIDbContext.ObjectContext.SaveChangesAsync();
            if (nbRowsAffected != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
