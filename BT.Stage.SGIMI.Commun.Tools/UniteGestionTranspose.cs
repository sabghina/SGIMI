using BT.Stage.SGIMI.Data.DTO;
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
                Type = uniteGestion.Type,
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
                Type = uniteGestionViewModel.Type,
                CreatedBy = user,
                CreatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                CreatedTime = DateTime.Now.ToString("HH:mm:ss")

            };
            return uniteGestion;
        }
        public static UniteGestion UpdatedUniteGestionViewModelToUpdatedUniteGestion(UniteGestionViewModel uniteGestionViewModel, string user)
        {
            UniteGestion uniteGestion = new UniteGestion
            {
                Id = uniteGestionViewModel.Id,
                Nom = uniteGestionViewModel.Nom,
                Email = uniteGestionViewModel.Email,
                Telephone = uniteGestionViewModel.Telephone,
                Adresse = uniteGestionViewModel.Adresse,
                Fax = uniteGestionViewModel.Fax,
                Type = uniteGestionViewModel.Type,
                LastUpdatedBy = user,
                LastUpdatedDate = DateTime.Now.ToString("dd/MM/yyyy"),
                LastUpdatedTime = DateTime.Now.ToString("HH:mm:ss")
            };

            return uniteGestion;
        }

        public static List<UniteGestionReport> UniteGestionListToUniteGestionReportList(List<UniteGestion> uniteGestions)
        {
            List<UniteGestionReport> uniteGestionReports = new List<UniteGestionReport>();
            foreach (UniteGestion uniteGestion in uniteGestions)
            {
                UniteGestionReport uniteGestionReport = UniteGestionToUniteGestionReport(uniteGestion);

                uniteGestionReports.Add(uniteGestionReport);
            }
            return uniteGestionReports;
        }

        public static UniteGestionReport UniteGestionToUniteGestionReport(UniteGestion uniteGestion)
        {
            UniteGestionReport uniteGestionReport = new UniteGestionReport
            {
                Nom = $"{uniteGestion.Nom}",
                Contact = $"Telephone :{uniteGestion.Telephone}/Fax: {uniteGestion.Fax}",
                Email = $"{uniteGestion.Email}",
                Adresse = $"{uniteGestion.Adresse}",
                Type = $"{uniteGestion.Type}"
            };

            return uniteGestionReport;
        }

    }
}
    


