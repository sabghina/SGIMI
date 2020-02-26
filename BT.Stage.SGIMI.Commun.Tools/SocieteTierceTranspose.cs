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
        public static List<SocieteTierceViewModel> SocieteTierceListToSocieteTierceViewModelList(List<SocieteTierce> societeTierces)
        {
            List<SocieteTierceViewModel> societeTierceViewModels = new List<SocieteTierceViewModel>();

            foreach (SocieteTierce societeTierce in societeTierces)
            {
                SocieteTierceViewModel societeTierceViewModel = SocieteTierceToSocieteTierceViewModel(societeTierce);

                societeTierceViewModels.Add(societeTierceViewModel);
            }

            return societeTierceViewModels;
        }

        public static SocieteTierceViewModel SocieteTierceToSocieteTierceViewModel(SocieteTierce societeTierce)
        {
            SocieteTierceViewModel societeTierceViewModel = new SocieteTierceViewModel
            {
                Id = societeTierce.Id,
                Nom = societeTierce.Nom,
                CreatedBy = societeTierce.CreatedBy
            };
            return societeTierceViewModel;
        }
    }
}
