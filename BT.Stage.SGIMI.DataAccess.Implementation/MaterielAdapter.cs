using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class MaterielAdapter : IMaterielAdapter
    {
        public Materiel GetMaterielById(int id)
        {
            // replace with database access
            Materiel materiel = new Materiel
            {
                Id = id,
                Nom = "Materiel" + id,
                Reference = "Mat00" + id,
                //Exemple pour le test
                Fournisseur = id + 1,
                CreatedBy = id + 1
            };

            return materiel;
        }
        public List<Materiel> GetMateriels()
        {
            // replace with databse access
            List<Materiel> materiels = new List<Materiel>();
            for (int i = 1; i < 10; i++)
            {
                Materiel materiel = new Materiel
                {
                    Id = i,
                    Nom = "Materiel" + i,
                    Reference = "Mat00" + i,
                    //Exemple pour le test
                    Fournisseur = i + 1,
                    CreatedBy = i + 1
                };

                    materiels.Add(materiel);
            }

            return materiels;
        }
    }
}

