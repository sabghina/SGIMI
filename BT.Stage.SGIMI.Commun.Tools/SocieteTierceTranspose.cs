using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Commun.Tools
{
    public static class SocieteTierceTranspose
    {
        public static List<SocieteTierceViewModel> FournisseurListToSocieteTierceViewModelList(List<Fournisseur> societeTierces)
        {
            List<SocieteTierceViewModel> societeTierceViewModels = new List<SocieteTierceViewModel>();

            foreach (Fournisseur societeTierce in societeTierces)
            {
                SocieteTierceViewModel societeTierceViewModel = FournisseurToSocieteTierceViewModel(societeTierce);

                societeTierceViewModels.Add(societeTierceViewModel);
            }

            return societeTierceViewModels;
        }

        public static SocieteTierceViewModel FournisseurToSocieteTierceViewModel(Fournisseur societeTierce)
        {
            SocieteTierceViewModel societeTierceViewModel = new SocieteTierceViewModel
            {
                Id = societeTierce.Id,
                Nom = societeTierce.Nom,
                CreatedBy = societeTierce.CreatedBy
            };
            return societeTierceViewModel;
        }

        public static Fournisseur SocieteTierceViewModelToSocieteTierce(SocieteTierceViewModel societeTierceViewModel, string user)
        {
            throw new NotImplementedException();
        }
    }
}
