using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.DataAccess.Implementation
{
    public class FournisseurAdapter : IFournisseurAdapter
    {
        public List<Fournisseur> GetFournisseurs()
        {
            List<Fournisseur> fournisseurs = new List<Fournisseur>();
            for (int i = 1; i < 10; i++)
            {
                Fournisseur fournisseur = new Fournisseur
                {
                    Id = i,
                    Nom = "Fournisseur" + i,
                    CreatedBy = i + 1
                };

                fournisseurs.Add(fournisseur);
            }

            return fournisseurs;
        }
    }
}
