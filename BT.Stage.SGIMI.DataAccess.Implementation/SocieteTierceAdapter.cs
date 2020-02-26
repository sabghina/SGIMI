using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{

    public class SocieteTierceAdapter : ISocieteTierceAdapter
    {

        public SocieteTierce GetSocieteTierceById(int id)
            {
                // replace with database access
                SocieteTierce societeTierce = new SocieteTierce
                {
                    Id = id,
                    Nom = "SocieteTierce" + id,
                    CreatedBy = id + 1
                };

                return societeTierce;
            }

            public List<SocieteTierce> GetSocieteTierces()
            {
                // replace with databse access
                List<SocieteTierce> societeTierces = new List<SocieteTierce>();
                for (int i = 1; i < 10; i++)
                {
                SocieteTierce societeTierce = new SocieteTierce
                    {
                        Id = i,
                        Nom = "SocieteTierce" + i,
                        CreatedBy = i + 1
                    };

                    societeTierces.Add(societeTierce);
                }
            return societeTierces;
            }
        }
    }
