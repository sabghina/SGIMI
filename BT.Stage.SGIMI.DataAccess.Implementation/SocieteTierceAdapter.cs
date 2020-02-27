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

        public Fournisseur GetSocieteTierceById(int id)
        {
            // replace with database access
            Fournisseur societeTierce = new Fournisseur
            {
                Id = id,
                Nom = "SocieteTierce" + id,
                CreatedBy = "user"+id + 1
            };

            return societeTierce;
        }

        public List<Fournisseur> GetSocieteTierces()
        {
            // replace with databse access
            List<Fournisseur> societeTierces = new List<Fournisseur>();
            for (int i = 1; i < 10; i++)
            {
                Fournisseur societeTierce = new Fournisseur
                {
                    Id = i,
                    Nom = "SocieteTierce" + i,
                    CreatedBy = "user"+i + 1
                };

                societeTierces.Add(societeTierce);
            }
            return societeTierces;
        }
    }
}
