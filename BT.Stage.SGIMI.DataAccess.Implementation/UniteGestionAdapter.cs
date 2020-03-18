using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class UniteGestionAdapter : IUniteGestionAdapter
    {
        public bool CreateUniteGestion(UniteGestion uniteGestion)
        {
            throw new NotImplementedException();
        }

        public bool CreateUniteGestionr(UniteGestion uniteGestion)
        {
            // ajout in database
            return true;
        }

        public UniteGestion GetUniteGestionById(int id)
        {
            // replace with database access
            UniteGestion uniteGestion = new UniteGestion
            {
                Id = id,
                Nom = "UniteGestion" + id,
                Email = "UniteGestion" + id,
                Telephone = "+216xxxxx",
                Fax = "7xxxxxx",
                Type = "Agence",
                Adresse = "Rue xxxxxxxx",
                LastUpdatedBy = "admin",
                LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")


            };

            return uniteGestion;
        }

        public List<UniteGestion> GetUniteGestions()
        {
            // replace with databse access
            List<UniteGestion> uniteGestions = new List<UniteGestion>();
            for (int i = 1; i < 10; i++)
            {
                UniteGestion uniteGestion = new UniteGestion
                {
                    Id = i,
                    Nom = "UniteGestion" + i,
                    Email = "UniteGestion" + i,
                    Telephone = "+216xxxxx",
                    Fax = "7xxxxxx",
                    Type = "Agence",
                    Adresse = "Rue xxxxxxxx",
                    LastUpdatedBy = "admin",
                    LastUpdatedDate = DateTime.Now.ToString("dddd, dd MMMM yyyy"),
                    LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")


                };

                uniteGestions.Add(uniteGestion);
            }

            return uniteGestions;
        }

        public bool UpdateUniteGestion(UniteGestion uniteGestion)
        {
            return true;
        }
    }
}
