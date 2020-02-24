using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Commun.Tools
{
    public static class FournisseurTranspose
    {
        public static List<FournisseurViewModel> FournisseurListToFournisseurViewModelList(List<Fournisseur> fournisseurs)
        {
            List<FournisseurViewModel> fournisseurViewModels = new List<FournisseurViewModel>();

            foreach (Fournisseur fournisseur in fournisseurs)
            {
                FournisseurViewModel fournisseurViewModel = FournisseurToFournisseurViewModel(fournisseur);

                fournisseurViewModels.Add(fournisseurViewModel);
            }

            return fournisseurViewModels;
        }
        
        public static FournisseurViewModel FournisseurToFournisseurViewModel(Fournisseur fournisseur)
        {
            FournisseurViewModel fournisseurViewModel = new FournisseurViewModel
            {
                Id = fournisseur.Id,
                Nom = fournisseur.Nom,
                CreatedBy = fournisseur.CreatedBy
            };
            return fournisseurViewModel;
        }
    }
}
