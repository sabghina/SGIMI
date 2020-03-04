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
                Email = fournisseur.Email,
                CreatedBy = fournisseur.CreatedBy
            };
            return fournisseurViewModel;
        }

        public static Fournisseur FournisseurViewModelToFournisseur(FournisseurViewModel fournisseurViewModel, string user)
        {
            Fournisseur fournisseur = new Fournisseur
            {
                Nom = fournisseurViewModel.Nom,
                Email = fournisseurViewModel.Email,
                Type = (char)fournisseurViewModel.Type,
                CreatedBy = user
            };
            return fournisseur;
        }
    }
}
