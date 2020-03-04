using BT.Stage.SGIMI.BusinessLogic.Interface;
using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.BusinessLogic.Implementation
{
    public class FournisseurRepository : IFournisseurRepository
    {
        readonly IFournisseurAdapter fournisseurAdapter;
        public FournisseurRepository(IFournisseurAdapter _fournisseurAdapter)
        {
            fournisseurAdapter = _fournisseurAdapter;
        }

        public bool CreateFournisseur(Fournisseur fournisseur)
        {
            // traitement
            return fournisseurAdapter.CreateFournisseur(fournisseur);
        }

        public Fournisseur GetFournisseurById(int id)
        {
            return fournisseurAdapter.GetFournisseurById(id);
        }

        public List<Fournisseur> GetFournisseurs()
        {
            List<Fournisseur> fournisseurs = fournisseurAdapter.GetFournisseurs();
            return fournisseurs;
        }

        public bool UpdatedFournisseur(Fournisseur fournisseur)
        {
            return fournisseurAdapter.UpdateFournisseur(fournisseur);
        }
    }
}
