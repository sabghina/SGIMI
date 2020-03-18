using BT.Stage.SGIMI.Data.Entity;
using BT.Stage.SGIMI.UserInterface.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT.Stage.SGIMI.Commun.Tools
{
    public static class UniteGestionTranspose
    {
        public static List<UniteGestionViewModel> UniteGestionListToUniteGestionViewModelList(List<UniteGestion> uniteGestions)
        {
            List<UniteGestionViewModel> uniteGestionViewModels = new List<UniteGestionViewModel>();

            foreach (UniteGestion uniteGestion in uniteGestions)
            {
                UniteGestionViewModel uniteGestionViewModel = UniteGestionToUniteGestionViewModel(uniteGestion);

                uniteGestionViewModels.Add(uniteGestionViewModel);
            }

            return uniteGestionViewModels;
        }

        public static UniteGestionViewModel UniteGestionToUniteGestionViewModel(UniteGestion uniteGestion)
        {
            UniteGestionViewModel uniteGestionViewModel = new UniteGestionViewModel
            {
                Id = uniteGestion.Id,
                Nom = uniteGestion.Nom,
                Email = uniteGestion.Email,
                Telephone = uniteGestion.Telephone,
                Adresse = uniteGestion.Adresse,
                Fax = uniteGestion.Fax,
                LastUpdatedDate = uniteGestion.LastUpdatedDate,
                LastUpdatedTime = uniteGestion.LastUpdatedTime,
                LastUpdatedBy = uniteGestion.LastUpdatedBy
            };
            return uniteGestionViewModel;
        }

        public static UniteGestion UniteGestionViewModelToUniteGestion(UniteGestionViewModel uniteGestionViewModel, string user)
        {
            UniteGestion uniteGestion = new UniteGestion
            {
                Nom = uniteGestionViewModel.Nom,
                Email = uniteGestionViewModel.Email,
                Telephone = uniteGestionViewModel.Telephone,
                Adresse = uniteGestionViewModel.Adresse,
                Fax = uniteGestionViewModel.Fax,
                LastUpdatedDate = uniteGestionViewModel.LastUpdatedDate,
                LastUpdatedTime = uniteGestionViewModel.LastUpdatedTime,
                LastUpdatedBy = uniteGestionViewModel.LastUpdatedBy

            };
            return uniteGestion;
        }
        public static UniteGestion UpdatedUniteGestionViewModelToUpdatedUniteGestion(int id, UniteGestionViewModel uniteGestionViewModel, string user)
        {
            UniteGestion uniteGestion = new UniteGestion
            {
                Id = id,
                Nom = uniteGestionViewModel.Nom,
                Email = uniteGestionViewModel.Email,
                Telephone = uniteGestionViewModel.Telephone,
                Adresse = uniteGestionViewModel.Adresse,
                Fax = uniteGestionViewModel.Fax,
                LastUpdatedDate = uniteGestionViewModel.LastUpdatedDate,
                LastUpdatedTime = uniteGestionViewModel.LastUpdatedTime,
                LastUpdatedBy = uniteGestionViewModel.LastUpdatedBy
            };

            return uniteGestion;
        }
    }
}
    


